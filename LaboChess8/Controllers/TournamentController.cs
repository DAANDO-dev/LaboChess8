using LaboChess8.DTO;
using LaboChess8.Entities;
using LaboChess8.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboChess8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController(LaboChessContext context) : ControllerBase
    {
        [HttpPatch]

        public IActionResult Tournament([FromBody] TournamentDTO dto)
        {


            // Check if MinPlayers and MaxPlayers are between 2 and 32


            if (dto.MinPlayers < 2 || dto.MinPlayers > 32 || dto.MaxPlayers < 2 || dto.MaxPlayers > 32)
            {
                return BadRequest("Player must be between 2 and 32");
            }

            // Check if MinPlayers is less than MaxPlayers
            if (dto.MinPlayers > dto.MaxPlayers)
            {
                return BadRequest("MinPlayers must be less than MaxPlayers");
            }
            // Check if MinELO and MaxELO are between 1000 and 3000
            if (dto.MinELO.HasValue && dto.MaxELO.HasValue &&
                dto.MinELO > dto.MaxELO)
            {
                return BadRequest("......Bla");
            }

            if (dto.RegistrationDeadline < DateTime.Now.AddDays(dto.MinPlayers))
            {
                return BadRequest("....");
            }


            context.Tournaments.Add(new Tournament
            {
                Name = dto.Name,
                Location = dto.Location,
                MinPlayers = dto.MinPlayers,
                MaxPlayers = dto.MaxPlayers,
                MinELO = dto.MinELO,
                MaxELO = dto.MaxELO,
                Categories = dto.Categories,
                CurrentRound = 0,
                Status = "waiting for players",
                CreationDate = DateTime.Now,
                Update = DateTime.Now,
                WomenOnly = dto.WomenOnly,
                RegistrationDeadLine = dto.RegistrationDeadline

            });


            context.SaveChanges();
            return Ok("Tournamen created successfully");
        }

        [HttpPatch("{id}/Start")]
        public IActionResult StartTournamet(int tournamentId)
        {
            Tournament? t = context.Tournaments
                .Include(t => t.Players)
                .FirstOrDefault(t => t.Id == tournamentId);

            if (t == null)
            {
                return BadRequest("Tournament not found");
            }


            if(t.Status != "waiting for players")
            {
                return BadRequest("Not enough players");
            }

            if (t.Players.Count < t.MinPlayers)
            {
                return BadRequest("Not enough players");
            }

            if (DateTime.Now < t.RegistrationDeadLine)
            {
                return BadRequest("Registration deadline has not passed yet");
            }

            t.CurrentRound = 0;
            t.Update = DateTime.Now;
            matchups(t.Players.Select(p => p.Id), t);
            context.SaveChanges();
            return Ok("Tournament started successfully");

        }
        List<Matchup> matchups(IEnumerable<int> Players, Tournament t)
        {

            List<Matchup> Result = new List<Matchup>();
            int[] temp = Players.ToArray();
            for (int i = 1; i < temp.Length; i++)
            {
                for (int j = 0; j < temp.Length / 2; j++)
                {
                    Result.Add(new Matchup
                    {
                        WhiteId = temp[j],
                        BlackId = temp[^(j + 1)],
                        Round = i,
                        Result = MatchResult.NotPlayed,
                        Tournament = t
                        
                    });

                    Result.Add(new Matchup
                    {
                        BlackId = temp[j],
                        WhiteId = temp[^(j + 1)],
                        Round = temp.Length - i,
                        Result = MatchResult.NotPlayed,
                        Tournament = t

                    });
                }
                temp = [temp.First(), temp.Last(), ..temp.Skip(1).SkipLast(1)];
            }

            context.Matchups.AddRange(Result);
            return Result;
        }

           
            [HttpGet]
            public IActionResult Available()
            {
                List<TournamentResultDTO> availableTournaments = context.Tournaments
                    .Where(t => t.Status != "finished")
                    .OrderByDescending(t => t.RegistrationDeadLine)
                    .Take(10)
                    .Select(t => new TournamentResultDTO
                    {
                        Name = t.Name,
                        Categories = t.Categories,
                        CurrentRound = t.CurrentRound,
                        Location = t.Location,
                        MaxPlayers = t.MaxPlayers,
                        MinPlayers = t.MinPlayers,
                        MaxELO = t.MaxELO,
                        MinELO = t.MinELO,
                        RegistrationDeadline = t.RegistrationDeadLine,
                        Status = t.Status,
                        RegisteredPlayersCount = t.Players.Count
                    })
                    .ToList();

                return Ok(availableTournaments);
            }
        




            [HttpDelete("{id}")]
            public IActionResult Remove(int id)
            {
                Tournament? toDelete = context.Tournaments.Find(id);
                if (toDelete == null)
                {
                    return NotFound();
                }
                if (toDelete.Status != "waiting for players")
                {
                    return BadRequest("Tournament is already started");
                }
                context.Tournaments.Remove(toDelete);
                context.SaveChanges();
                return Ok("Tournament deleted successfully");
            }
        
    }
}
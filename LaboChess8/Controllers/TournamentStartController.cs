using LaboChess8.DTO;
using LaboChess8.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboChess8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentStartController(LaboChessContext context) : ControllerBase
    {
        [HttpPatch("Start")]
        public IActionResult StartTournamet(int tournamentId)
        {
            Tournament? t = context.Tournaments
                .Include(t => t.Players)
                .FirstOrDefault(t => t.Id == tournamentId);

            if ( t == null)
            {
                return BadRequest("Tournament not found");
            }

            if(t.Players.Count < t.MinPlayers)
            {
                return BadRequest("Not enough players");
            }

            if(DateTime.Now < t.RegistrationDeadLine)
            {
                return BadRequest("Registration deadline has not passed yet");
            }

            t.CurrentRound = 1;
            t.Update = DateTime.Now;
            return Ok("Tournament started successfully");


        }
        








    }






}


      //{
        //    Tournament? tournament = context.Tournaments.Find(tournamentId);
        //    if (tournament == null)
        //    {
        //        return NotFound();
        //    }
        //    if (tournament.Status != "waiting for players")
        //    {
        //        return BadRequest("Tournament is already started");
        //    }
        //    if (tournament.Players.Count < tournament.MinPlayers)
        //    {
        //        return BadRequest("Not enough players");
        //    }
        //    tournament.Status = "started";
        //    context.SaveChanges();
        //    return Ok("Tournament started successfully");
        //}

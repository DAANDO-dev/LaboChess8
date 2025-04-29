using LaboChess8.Entities;
using LaboChess8.Interface.Repositories.Interface;
using LaboChess8.Interface.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Numerics;
using LaboChess8.DTO;
using LaboChess8.Enum;
using Microsoft.EntityFrameworkCore;

namespace LaboChess8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentInscription(LaboChessContext context) : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody] InscriptionDTO dto)
        {
            // Register a Player for a  Tournament
            Tournament? t = context.Tournaments.Include(t => t.Players).FirstOrDefault(t => t.Id == dto.TournamentId);
            Member? m = context.Members.Find(dto.PlayerId);

            if (t is null || m is null)
            {
                return BadRequest("Tournament or player not found");
            }

            if (t.Status != "waiting for players")
            {
                return BadRequest("Tournament is finished or has already started");
            }

            // If player is smaller then 18 years old he can participate in Junior Category
            int age = t.RegistrationDeadLine.Year - m.BirthDate.Year;

            if (new DateTime(t.RegistrationDeadLine.Year, m.BirthDate.Month, m.BirthDate.Day) < t.RegistrationDeadLine)
            {
                age--;
            }

            if (age < 18 && !t.Categories.HasFlag(ListCategories.Junior))
            {
                return (BadRequest("Registration Failed: Player is under 18 years old"));
            }

            if (age >= 18 && age < 60 && !t.Categories.HasFlag(ListCategories.Senior))
            {
                return BadRequest("Category: Senior");
            }
            if (age >= 60 && !t.Categories.HasFlag(ListCategories.Veteran))
            {
                return BadRequest("Category: Veteran");
            }
            if (t.MaxPlayers <= t.Players.Count)
            {
                return BadRequest("Registration Failed: Tournament is full");
            }


            if (t.WomenOnly && m.Gender == Gender.MALE)
            {
                return BadRequest("Registration failed: Only female genders are allowed to participate in this tournament.");
            }

            if ((t.MinELO.HasValue && m.ELO >= t.MinELO) ||
                (t.MaxELO.HasValue && m.ELO <= t.MaxELO))
            {
                return BadRequest("Registration failed: Player's ELO rating is out of range for this tournament.");
            }

            t.Players.Add(m);
            context.SaveChanges();

            return Ok($"Player {m.Username} has been successfully registered into the tournament.");

        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]InscriptionDTO dto)
        {
            // Unregister a Player from a Tournament

            Tournament? t = context.Tournaments.Include(t => t.Players).FirstOrDefault(t => t.Id == dto.TournamentId);
            Member? m = context.Members.Find(dto.PlayerId);

            if (t is null || m is null)
            {
                return BadRequest("Tournament or player not found");
            }

            t.Players.Remove(m);
            context.SaveChanges();

            return Ok($"Player {m.Username} has been successfully unregistered from the tournament.");



        }

    }
}

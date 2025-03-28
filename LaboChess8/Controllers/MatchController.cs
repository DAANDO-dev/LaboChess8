using System.Text.RegularExpressions;
using LaboChess8.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboChess8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController(LaboChessContext context) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetTournamentDetails([FromQuery] int tournamentId, [FromQuery] int round)
        {
            // Validate input

            if (round <= 0)
            {
                return BadRequest("Round must be greater than 0.");
            }

            // Placeholder for actual logic to retrieve tournament details

            List<MatchDTO> m = context.Matchups.Where(m => m.TournamentId == tournamentId && m.Round == round).Select(m => new MatchDTO
            {
                blackId = m.BlackId,
                TournamentId = m.TournamentId,
                whiteId = m.WhiteId,
                Id = m.Id,
                result = m.Result,
                round = m.Round,
                blackName = m.Black.Username,
                whiteName = m.White.Username
            }).ToList();

            return Ok(m);
        }


    
   
   
        //// PATCH: api/Match/{id}/result
        //[HttpPatch("{id}/result")]
        //public IActionResult UpdateMatchResult([FromBody] MatchResultDTO dto)
        //{
        //    MatchDTO? m = context.Match.Find(dto.id);
        //    // Validate input
        //    if (id <= 0)
        //    {
        //        return BadRequest("Invalid match ID.");
        //    }

        //    if (dto == null || dto.Result == null)
        //    {
        //        return BadRequest("Invalid match result data.");
        //    }

           

        //    // Placeholder for logic to update match result in database
        //    // e.g., MatchService.UpdateMatchResult(id, matchResultDto);

        //    return Ok(new
        //    {
        //        Message = "Match result updated successfully.",
        //        MatchId = id,
        //        Result = dto.Result
        //    });

        //}

    }
}

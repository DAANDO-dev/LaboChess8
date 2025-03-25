using System.Security.Cryptography;
using System.Text;
using LaboChess8.DTO;
using LaboChess8.Entities;
using LaboChess8.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboChess8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(LaboChessContext context) : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RegisterMemberDTO dto)
        {
            if(context.Members.Any(m => m.Username == dto.Username))
            {
                return BadRequest();
            }

            if (context.Members.Any(m => m.Email == dto.Email))
            {
                return BadRequest();
            }

            string givenPassword = "1234";
            Guid guid = Guid.NewGuid();
            string hashedPassword = Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes(givenPassword + guid)));

            context.Members.Add(new Member
            {
                Email = dto.Email,
                Username = dto.Username,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                ELO = dto.Elo ?? 1200,
                Role = Role.Member,
                Password = hashedPassword,
                Salt = guid,
            });

            context.SaveChanges();

            return Ok();
        }
    }
}

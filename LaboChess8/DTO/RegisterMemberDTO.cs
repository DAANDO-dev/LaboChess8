using System.ComponentModel.DataAnnotations;
using LaboChess8.Enum;

namespace LaboChess8.DTO
{
    public class RegisterMemberDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [MaxLength(20)]
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Range(0, 3000)]
        public int? Elo { get; set; }
    }
}

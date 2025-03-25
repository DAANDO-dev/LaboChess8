using LaboChess8.Enum;

namespace LaboChess8.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int  ELO { get; set; }
        public Role Role { get; set; }
        public Guid Salt { get; set; }
        public List<Tournament> Tournaments { get; set; }
    }
}

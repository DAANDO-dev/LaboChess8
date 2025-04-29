using LaboChess8.Enum;

namespace LaboChess8.DTO
{
    public class TournamentDTO
    {
        public string Name { get; set; }
        public string? Location { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int? MinELO { get; set; }
        public int? MaxELO { get; set; }
        public bool isRegistered { get; set; }
        public int currentRound { get; set; }
        public bool canRegister { get; set; }
        public ListCategories Categories { get; set; }// junior, senior, veteran
        public bool WomenOnly { get; set; }
        public DateTime RegistrationDeadline { get; set; } 
    }
}

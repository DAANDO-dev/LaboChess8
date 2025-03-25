using LaboChess8.Enum;

namespace LaboChess8.DTO
{
    public class TournamentResultDTO
    {
        public string Name { get; set; }
        public string? Location { get; set; }

        public int RegisteredPlayersCount { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int? MinELO { get; set; }
        public int? MaxELO { get; set; }
        public ListCategories Categories { get; set; }// junior, senior, veteran
        public DateTime RegistrationDeadline { get; set; }
        public string Status { get; set; }
        public int CurrentRound { get; set; }
    }
}

using LaboChess8.Enum;

namespace LaboChess8.Entities
{
    public class Tournament
    {
        public int  Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int? MinELO { get; set; }
        public int? MaxELO { get; set; }
        public ListCategories Categories { get; set; }

        public string Status { get; set; }  // <= Default Status "In progress" or "Finished"
        public int CurrentRound { get; set; }
        public bool WomenOnly { get; set; }
        public DateTime RegistrationDeadLine { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime Update { get; set; } = DateTime.Now;
        public List<Member> Players { get; set; }
        public List<Matchup> Matchups{ get; set; }


    }
}

using LaboChess8.Enum;

namespace LaboChess8.Entities
{
    public class Matchup
    {
        public int Id { get; set; }
        public MatchResult  Result { get; set; }
        public int Round { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int WhiteId { get; set; }
        public Member White { get; set; }
        public int BlackId { get; set; }
        public Member Black { get; set; }
    }
}

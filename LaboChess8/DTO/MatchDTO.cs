using LaboChess8.Enum;

namespace LaboChess8.DTO
{
    public class MatchDTO 
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public string blackName { get; set; } = null!;
        public int blackId { get; set; }
        public string whiteName { get; set; } = null!;
        public int whiteId { get; set; }
        public MatchResult result { get; set; }
        public int round { get; set; }
    }
}

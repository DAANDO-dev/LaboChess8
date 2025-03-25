using LaboChess8.Entities;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace LaboChess8.Repositories
{
    public class TournamentRepositiries(LaboChessContext context)
    {
        public void Add(Tournament tournament)
        {
            // insert in DB one tournament
            context.Tournaments.Add(tournament);
        }
    }
}

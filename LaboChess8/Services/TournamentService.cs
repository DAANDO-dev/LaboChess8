using LaboChess8.Entities;
using LaboChess8.Interface.Repositories;
using LaboChess8.Interface.Repositories.Interface;
using LaboChess8.Repositories;

namespace LaboChess8.Services
{
    public class TournamentService(ITournamentRepository tournamentRepo, IMemberRepository memberRepo)
    {
        public void RegisterPlayer(int playerId, int tournamentId)
        {
           // Tournament tournament = tournamentRepo.G(tournamentId);

            // verify all the creating rules   

            // register somewhere ( in the DB)

            // send email to all the members
        }
    }
}

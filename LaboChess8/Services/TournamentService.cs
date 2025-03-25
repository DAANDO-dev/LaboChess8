using LaboChess8.Interface.Repositories;
using LaboChess8.Repositories;

namespace LaboChess8.Services
{
    public class TournamentService(ITournamentRepository repo)
    {
        public void CreateTournament()
        {
            // verify all the creating rules

            // register somewhere ( in the DB)

            // send email to all the members
        }
    }
}

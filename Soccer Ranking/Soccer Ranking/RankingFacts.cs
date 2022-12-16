using Xunit;

namespace SoccerRanking
{
    public class RankingFacts
    {
        [Fact]
        public void AddTeamToRankingAddOneTeamShouldReturnTrue()
        {
            Team[] teams =
            {
                new Team("Aerostar Bacau", 8),
                new Team("CS Afumati", 5)
            };

            Ranking ranking = new Ranking(teams);

            Team newTeam = new Team("CSM Deva", 12);

            ranking.AddTeamToRanking(newTeam);

            Assert.True(ranking.PositionOf(newTeam) == 1);
        }
    }
}
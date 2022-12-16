using Xunit;

namespace SoccerRanking
{
    public class RankingFacts
    {
        [Fact]
        public void AddTeamToRankingAddOneTeamShouldReturnTrue()
        {
            Ranking ranking = new Ranking();

            Team newTeam = new Team("CSM Deva", 12);

            ranking.AddTeamToRanking(newTeam);

            Assert.True(ranking.PositionOf(newTeam) == 1);
        }
    }
}
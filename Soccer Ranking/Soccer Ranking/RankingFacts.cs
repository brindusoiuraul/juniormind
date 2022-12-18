using Newtonsoft.Json;
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

        [Fact]
        public void GetTeamByPositionCheckOneTeamShouldReturnRealMadrid()
        {
            Ranking ranking = new Ranking();

            Team firstTeam = new Team("FC Barcelona", 25);
            Team secondTeam = new Team("Real Madrid", 23);
            Team thirdTeam = new Team("Chelsea", 20);

            ranking.AddTeamToRanking(firstTeam);
            ranking.AddTeamToRanking(secondTeam);
            ranking.AddTeamToRanking(thirdTeam);

            var firstObj = JsonConvert.SerializeObject(new Team("Real Madrid", 23));
            var secondObj = JsonConvert.SerializeObject(ranking.GetTeamByPosition(2));

            Assert.Equal(firstObj, secondObj);
        }

        [Fact]
        public void GetTeamByPositionCheckOneTeamShouldReturnNull()
        {
            Ranking ranking = new Ranking();

            Team firstTeam = new Team("FC Cojasca", 5);
            Team secondTeam = new Team("FC Leamna", 3);

            ranking.AddTeamToRanking(firstTeam);
            ranking.AddTeamToRanking(secondTeam);

            var firstObj = JsonConvert.SerializeObject(null);
            var secondObj = JsonConvert.SerializeObject(ranking.GetTeamByPosition(3));

            Assert.Equal(firstObj, secondObj);
        }
    }
}
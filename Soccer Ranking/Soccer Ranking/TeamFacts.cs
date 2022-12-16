using Xunit;

namespace SoccerRanking
{
    public class TeamFacts
    {
        [Fact]
        public void HasMorePointsThan()
        {
            Team firstTeam = new Team("CFR Cluj", 15);
            Team secondTeam = new Team("Astra Giurgiu", 17);

            Assert.False(firstTeam.HasMorePointsThan(secondTeam));
        }
    }
}
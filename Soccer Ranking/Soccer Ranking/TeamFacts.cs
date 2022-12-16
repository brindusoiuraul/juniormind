using Xunit;

namespace SoccerRanking
{
    public class TeamFacts
    {
        [Fact]
        public void HasMorePointsThanCheckForTwoTeamsFirstTeamHasLessPointsThanSecondTeamShouldReturnFalse()
        {
            Team firstTeam = new Team("CFR Cluj", 15);
            Team secondTeam = new Team("Astra Giurgiu", 17);

            Assert.False(firstTeam.HasMorePointsThan(secondTeam));
        }

        [Fact]
        public void HasMorePointsThanCheckForTwoTeamsFirstTeamHasMorePointsThanSecondTeamShouldReturnTrue()
        {
            Team firstTeam = new Team("Steaua Bucuresti", 23);
            Team secondTeam = new Team("Dinamo Bucuresti", 12);

            Assert.True(firstTeam.HasMorePointsThan(secondTeam));
        }

        [Fact]
        public void HasMorePointsThanCheckForTwoTeamsBothTeamPointsEqualShouldReturnFalse()
        {
            Team firstTeam = new Team("Gaz Metan Medias", 10);
            Team secondTeam = new Team("Rapid", 10);

            Assert.False(firstTeam.HasMorePointsThan(secondTeam));
        }
    }
}
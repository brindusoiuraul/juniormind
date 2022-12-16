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

        [Fact]
        public void AddPointsToTeamCheckIfPointsAreAddedToATeam()
        {
            Team firstTeam = new Team("FC Unirea Urziceni", 15);
            Team secondTeam = new Team("Sporting Rosiori", 15);

            Assert.False(firstTeam.HasMorePointsThan(secondTeam));

            firstTeam.AddPointsToTeam(2);

            Assert.True(firstTeam.HasMorePointsThan(secondTeam));
        }

        [Fact]
        public void AddPointsToTeamCheckIfPointsAreAddedToBothTeams()
        {
            Team firstTeam = new Team("FC Politehnica Iasi", 8);
            Team secondTeam = new Team("CS Concordia Chiajna", 8);

            Assert.False(firstTeam.HasMorePointsThan(secondTeam));

            firstTeam.AddPointsToTeam(3);
            secondTeam.AddPointsToTeam(5);

            Assert.False(firstTeam.HasMorePointsThan(secondTeam));
        }
    }
}
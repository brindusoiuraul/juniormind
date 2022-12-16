using System;

namespace SoccerRanking
{
    public class Team
    {
        readonly string name;
        private int points;

        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public bool HasMorePointsThan(Team teamToCheck)
        {
            return this.points > teamToCheck.points;
        }

        public void AddPointsToTeam(int numberOfPoints)
        {
            this.points += numberOfPoints;
        }
    }
}
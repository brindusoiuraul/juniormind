using System;

namespace SoccerRanking
{
    public class Ranking
    {
        private Team[] teams;

        public Ranking()
        {
            this.teams = new Team[0];
        }

        public void AddTeamToRanking(Team teamToAdd)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = teamToAdd;
            SortTeamsByPoints();
        }

        public Team? GetTeamByPosition(int position)
        {
            return teams.Length < position ? teams[position - 1] : null;
        }

        public void UpdateRanking(Team firstTeam, Team secondTeam, int firstTeamPoints, int secondTeamPoints)
        {
            firstTeam.AddPoints(firstTeamPoints);
            secondTeam.AddPoints(secondTeamPoints);

            SortTeamsByPoints();
        }

        public int PositionOf(Team teamToGetPosition)
        {
            for (int index = 0; index < teams.Length; index++)
            {
                if (teams[index] == teamToGetPosition)
                {
                    return index + 1;
                }
            }

            return -1;
        }

        private void SortTeamsByPoints()
        {
            for (int i = 0; i < teams.Length - 1; i++)
            {
                for (int j = i + 1; j > 0 && teams[i].HasMorePointsThan(teams[j]); j--)
                {
                    Team tempTeam = teams[j - 1];
                    teams[j - 1] = teams[j];
                    teams[j] = tempTeam;
                }
            }
        }
    }
}
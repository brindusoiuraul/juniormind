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
            int position = 1;

            foreach (Team team in teams)
            {
                if (team == teamToGetPosition)
                {
                    return position;
                }

                position++;
            }

            return -1;
        }

        private void SortTeamsByPoints()
        {
            for (int i = 1; i < teams.Length; i++)
            {
                int j = i - 1;
                while (j >= 0 && teams[i].HasMorePointsThan(teams[j]))
                {
                    teams[j + 1] = teams[j];
                    j--;
                }

                teams[j + 1] = teams[i];
            }
        }
    }
}
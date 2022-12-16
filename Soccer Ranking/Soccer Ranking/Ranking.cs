using System;

namespace SoccerRanking
{
    public class Ranking
    {
        private Team[] teams;

        public Ranking(Team[] teams)
        {
            this.teams = teams;
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
            const int divide = 2;

            for (int i = teams.Length / 2; i > 0; i /= divide)
            {
                for (int j = i; j < teams.Length; j++)
                {
                    Team tempTeam = teams[j];

                    int x;
                    for (x = j; x >= i && tempTeam.HasMorePointsThan(teams[x - i]); x -= i)
                    {
                        teams[x] = teams[x - i];
                    }

                    teams[x] = tempTeam;
                }
            }
        }
    }
}
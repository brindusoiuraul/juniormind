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
            SortTeamsByPoints(teams);
        }

        public Team? GetTeamByPosition(int position)
        {
            return teams.Length < position ? teams[position - 1] : null;
        }

        public void UpdateRanking(Team firstTeam, Team secondTeam, int firstTeamPoints, int secondTeamPoints)
        {
            firstTeam.AddPointsToTeam(firstTeamPoints);
            secondTeam.AddPointsToTeam(secondTeamPoints);

            SortTeamsByPoints(teams);
        }

        public int GetTeamPosition(Team teamToGetPosition)
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

        static void SortTeamsByPoints(Team[] teamsToSort)
        {
            const int divide = 2;

            for (int i = teamsToSort.Length / 2; i > 0; i /= divide)
            {
                for (int j = i; j < teamsToSort.Length; j++)
                {
                    Team tempTeam = teamsToSort[j];

                    int x;
                    for (x = j; x >= i && tempTeam.HasMorePointsThan(teamsToSort[x - i]); x -= i)
                    {
                        teamsToSort[x] = teamsToSort[x - i];
                    }

                    teamsToSort[x] = tempTeam;
                }
            }
        }
    }
}
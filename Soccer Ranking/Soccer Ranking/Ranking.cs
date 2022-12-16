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
        }

        public Team GetTeamByPosition(int position)
        {

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
    }
}
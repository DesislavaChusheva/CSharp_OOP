using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                try
                {
                    string[] cmdArg = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    string action = cmdArg[0];
                    string theTeam = cmdArg[1];

                    if (action == "Team")
                    {
                        Team team = new Team(theTeam);
                        teams.Add(team);
                    }

                    else if (action == "Rating")
                    {
                        Team team = teams.Where(t => t.Name == theTeam).FirstOrDefault();
                        if (team != null)
                        {
                            Console.WriteLine($"{team.Name} - {team.GetRating()}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {theTeam} does not exist.");
                        }
                    }

                    else
                    {
                        string playerName = cmdArg[2];


                        if (action == "Add")
                        {
                            Team team = teams.Where(t => t.Name == theTeam).FirstOrDefault();
                            if (team != null)
                            {
                                int endurance = int.Parse(cmdArg[3]);
                                int sprint = int.Parse(cmdArg[4]);
                                int dribble = int.Parse(cmdArg[5]);
                                int passing = int.Parse(cmdArg[6]);
                                int shooting = int.Parse(cmdArg[7]);

                                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                team.AddPlayer(player);
                            }
                            else
                            {
                                Console.WriteLine($"Team {theTeam} does not exist.");
                            }
                        }
                        else if (action == "Remove")
                        {
                            Team team = teams.Where(t => t.Name == theTeam).FirstOrDefault();
                            if (team != null)
                            {
                                team.RemovePlayer(playerName);
                            }
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }



                command = Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    public  class Day2
    {
        public enum Play
        {
            Unknown = -1,
            Rock = 1,
            Paper = 2,
            Scissor = 3
        }

        public enum Outcome
        {
            Unknown = -1,   
            Lost = 0,
            Draw = 3,
            Win = 6
        }

        private static Play GetPlay(string s)
        {
            switch(s)
            {
                case "A":
                case "X":
                    return Play.Rock;
                case "B": 
                case "Y":
                    return Play.Paper;
                case "C":
                case "Z":
                    return Play.Scissor;
            }

            return Play.Unknown;
        }

        private static Outcome GetOutcome(string s) =>
            s switch
            {
                "X" => Outcome.Lost,
                "Y" => Outcome.Draw,
                "Z" => Outcome.Win,
                _ => Outcome.Unknown
            };
        

        private static int GetScore(Outcome outcome) =>
            outcome switch
            {
                Outcome.Lost => 0,
                Outcome.Draw => 3,
                Outcome.Win => 6,
                _ => -1
            };

        private static int PlayScore(Play p) =>
            p switch
            {
                Play.Rock => 1,
                Play.Paper => 2,
                Play.Scissor => 3,
                _ => -1
            };

        private static int ResolveAndScore(Play theirs, Play mine)
        {
            Outcome outcome = Outcome.Unknown;
            if (theirs == mine) outcome = Outcome.Draw;
 
            if (theirs == Play.Rock && mine == Play.Paper) outcome = Outcome.Win;
            if (theirs == Play.Paper && mine == Play.Rock) outcome = Outcome.Lost;

            if (theirs == Play.Rock && mine == Play.Scissor) outcome = Outcome.Lost;
            if (theirs == Play.Scissor && mine == Play.Rock) outcome = Outcome.Win;

            if (theirs == Play.Scissor && mine == Play.Paper) outcome = Outcome.Lost;
            if (theirs == Play.Paper && mine == Play.Scissor) outcome = Outcome.Win;

            return PlayScore(mine) + GetScore(outcome); 
        }

        private static int FindPlayAndScore(Play theirs, Outcome o)
        {
            Play mine = Play.Unknown;

            if (theirs == Play.Rock)
            {
                if (o == Outcome.Lost) mine = Play.Scissor;
                if (o == Outcome.Draw) mine = Play.Rock;
                if (o == Outcome.Win) mine = Play.Paper;
            }
            else if (theirs == Play.Paper)
            {
                if (o == Outcome.Lost) mine = Play.Rock;
                if (o == Outcome.Draw) mine = Play.Paper;
                if (o == Outcome.Win) mine = Play.Scissor;
            }
            else if (theirs == Play.Scissor)
            {
                if (o == Outcome.Lost) mine = Play.Paper;
                if (o == Outcome.Draw) mine = Play.Scissor;
                if (o == Outcome.Win) mine = Play.Rock;
            }

            return PlayScore(mine) + GetScore(o);
        }


        public static void Part1()
        {
            var input = File.ReadAllLines("../../../Input/Day2.txt");

            var plays = input.Select(s => s.Split(" ").Select(s => GetPlay(s)).ToArray());
            var scored = plays.Select(p => ResolveAndScore(p[0], p[1]));
            var score = scored.Sum();

            Console.WriteLine($"Score: {score}");
        }

        public static void Part2()
        {
            var input = File.ReadAllLines("../../../Input/Day2.txt");

            var plays = input.Select(s => s.Split(" ").ToArray());
            var scored = plays.Select(s => FindPlayAndScore(GetPlay(s[0]), GetOutcome(s[1])));
            var score = scored.Sum();

            Console.WriteLine($"Score: {score}");
        }
    }
}

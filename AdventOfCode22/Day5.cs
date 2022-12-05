using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Day5
    {
        internal class Field
        {
            public List<string> Stacks { get; set; }

            public Field()
            {
                Stacks = new List<string>();    
            }

            public void LoadLine(string line)
            {
                for (int i = 0; i < 9; i++)
                {
                    int index = i * 4 + 1;

                    if (Stacks.Count() <= i)
                    {
                        Stacks.Add(string.Empty);
                    }

                    if (line[index] != ' ')
                    {
                        Stacks[i] += line[index];
                    }
                }
            }

            public void Move(Move m)
            {
                var s = Stacks[m.From].Substring(0, m.Count);
                var rev = string.Join("", s.Reverse()); 
                Stacks[m.From] = Stacks[m.From].Substring(m.Count);
                Stacks[m.To] = rev + Stacks[m.To];
            }

            public void MoveStack(Move m)
            {
                var s = Stacks[m.From].Substring(0, m.Count);
                Stacks[m.From] = Stacks[m.From].Substring(m.Count);
                Stacks[m.To] = s + Stacks[m.To];
            }

            public string TopCrates()
            {
                return String.Join("", Stacks.Select(s => s[0]));
            }
        }

        internal class Move
        {
            public int Count { get; set; }
            public int From { get; set; }
            public int To { get; set; }

            public Move(string s)
            {
                var parts = s.Split(' ');
                Count = Convert.ToInt32(parts[1]);
                From = Convert.ToInt32(parts[3]) - 1;
                To = Convert.ToInt32(parts[5]) - 1;
            }
        }


        public static void Part1()
        {
            var input = File.ReadAllLines("../../../Input/Day5.txt");

            var field = new Field();

            int i = 0;
            while (input[i].Contains('['))
            {
                field.LoadLine(input[i]);
                i++;
            }
            i += 2;

            var moves = input.Skip(i).Select(s => new Move(s)); 
            foreach (var m in moves)
            {
                field.Move(m);
            }

            Console.WriteLine($"Part1: TopStack: {field.TopCrates()}");
        }

        public static void Part2()
        {
            var input = File.ReadAllLines("../../../Input/Day5.txt");

            var field = new Field();

            int i = 0;
            while (input[i].Contains('['))
            {
                field.LoadLine(input[i]);
                i++;
            }
            i += 2;

            var moves = input.Skip(i).Select(s => new Move(s));
            foreach (var m in moves)
            {
                field.MoveStack(m);
            }

            Console.WriteLine($"Part2: TopStack: {field.TopCrates()}");
        }
    }
}
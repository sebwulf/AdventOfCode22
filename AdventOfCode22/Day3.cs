using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Day3
    {
        public class Rucksack
        {
            public string Comp1 { get; set; }
            public string Comp2 { get; set; }

            public Rucksack(string s)
            {
                Comp1 = s.Substring(0, s.Length / 2);
                Comp2 = s.Substring(s.Length / 2);
            }

            //public string GetCommon()
            //{
            //    var x = Comp1.GroupBy(c => c)
            //        .Join(
            //            Comp2.GroupBy(c => c),
            //            g => g.Key,
            //            g => g.Key,
            //            (lg, rg) => lg.Zip(rg, (l, r) => l).Count());

            //    return x.
            //}

            public char GetCommon()
            {
                foreach (char c in Comp1)
                {
                    foreach(char d in Comp2)
                    {
                        if (d == c) return c; 
                    }
                }

                return ' ';
            }
        }

        public char GetCommon(string s1, string s2)
        {
            foreach (char c in s1)
            {
                foreach (char d in s2)
                {
                    if (d == c) return c;
                }
            }

            return ' ';
        }

        public static int GetPrio(char c)
        {
            if ('a' <= c && c <= 'z')
            {
                return (int)(c - 'a' + 1);
            }
            else if ('A' <= c && c <= 'Z')
            {
                return (int)(c - 'A' + 27);
            }

            return 0;
        }

        public static char GetCommon(Rucksack[] rs)
        {
            var s2 = rs[1].Comp1 + rs[1].Comp2;
            var s3 = rs[2].Comp1 + rs[2].Comp2;

            foreach (var c in (rs[0].Comp1 + rs[0].Comp2))
            {
                if (s2.Contains(c) && s3.Contains(c)) return c;
            }

            return ' ';
        }

        public static void Part1()
        {
            var input = File.ReadAllLines("../../../Input/Day3.txt");

            var rucksacks = input.Select(s => new Rucksack(s));
            var commons = rucksacks.Select(r => r.GetCommon());
            var sum = commons.Select(c => GetPrio(c)).ToList().Sum();

            Console.WriteLine($"Part 1 Sum Prios: {sum}");

        }

        public static void Part2()
        {
            var input = File.ReadAllLines("../../../Input/Day3.txt");

            var rucksacks = input.Select(s => new Rucksack(s));
            var grouped = rucksacks.Chunk(3);
            var sum = grouped.Select(rs => GetPrio(GetCommon(rs))).Sum();

            Console.WriteLine($"Part 2 Sum Prios: {sum}");
        }
    }
}

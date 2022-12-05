using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Pairing
    {
        public int Start1 { get; set; }
        public int End1 { get; set; }
        public int Start2 { get; set; }
        public int End2 { get; set; }

        public Pairing(string s)
        {
            var pairs = s.Split(',');
            var p1 = pairs[0].Split('-');
            var p2 = pairs[1].Split('-');

            Start1 = Convert.ToInt32(p1[0]);
            End1 = Convert.ToInt32(p1[1]);

            Start2 = Convert.ToInt32(p2[0]);
            End2 = Convert.ToInt32(p2[1]);
        }

        public bool SectionsIncluded()
        {
            if (Start1 <= Start2 && End2 <= End1) 
                return true;
            if (Start2 <= Start1 && End1 <= End2) 
                return true;

            return false;
        }

        public bool SectionsOverlap()
        {
            if (End1 < Start2 ||
                End2 < Start1)
                return false;

            return true;
        }

    }

    internal class Day4
    {
        public static void Part1()
        {
            var input = File.ReadAllLines("../../../Input/Day4.txt");
            var included_pairs = input.Select(s => new Pairing(s)).Select(p => p.SectionsIncluded()).Where(b => b).Count();

            Console.WriteLine($"Part1: Included pairs: {included_pairs}");

        }

        public static void Part2()
        {
            var input = File.ReadAllLines("../../../Input/Day4.txt");
            var included_pairs = input.Select(s => new Pairing(s)).Select(p => p.SectionsOverlap()).Where(b => b).Count();

            Console.WriteLine($"Part2: Included pairs: {included_pairs}");
        }
    }
}

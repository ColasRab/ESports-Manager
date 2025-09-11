using System;
using System.Collections.Generic;

namespace ESportsManager.Maps
{
        public class Dust2
        {
        private Dictionary<string, List<(string, int)>> positions = new Dictionary<string, List<(string, int)>>();

        public void AddVertex(string position)
        {
            if (!positions.ContainsKey(position))
            {
                positions[position] = new List<(string, int)>();
            }
        }

        public void AddEdge(string from, string to, int time)
        {
            AddVertex(from);
            AddVertex(to);
            positions[from].Add((to, time));
            positions[to].Add((from, time));
        }

        public void DisplayMap()
        {
            foreach (var position in positions)
            {
                Console.Write(position.Key + " -> ");
                foreach (var edge in position.Value)
                {
                    Console.Write($"({edge.Item1}, {edge.Item2}) ");
                }
                Console.WriteLine();
            }
        }
    }
}
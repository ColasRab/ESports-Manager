using System;
using System.Collections.Generic;

namespace ESportsManager.Maps
{
    public class MapLoader
    {
        private Dictionary<string, List<(string, int)>> positions = new Dictionary<string, List<(string, int)>>();
        private Dictionary<string, List<string>> targets = new Dictionary<string, List<string>>();

        public void AddPositionVertex(string position)
        {
            if (!positions.ContainsKey(position))
            {
                positions[position] = new List<(string, int)>();
            }
        }

        public void AddTargetVertex(string target)
        {
            if (!targets.ContainsKey(target))
            {
                targets[target] = new List<string>();
            }
        }

        public void AddEdge(string from, string to, int time)
        {
            AddPositionVertex(from);
            AddPositionVertex(to);
            positions[from].Add((to, time));
            positions[to].Add((from, time));
        }

        public void AddEdge(string from, string to)
        {
            AddTargetVertex(from);
            AddTargetVertex(to);
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

        public List<string> FindPath(string start, string end)
        {
            var queue = new Queue<(string, List<string>)>();
            var visited = new HashSet<string>();

            queue.Enqueue((start, new List<string> { start }));
            visited.Add(start);

            while (queue.Count > 0)
            {
                var (current, path) = queue.Dequeue();

                if (current == end)
                {
                    return path;
                }

                if (positions.ContainsKey(current))
                {
                    foreach (var (neighbor, cost) in positions[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);

                            var newPath = new List<string>(path) { neighbor };
                            queue.Enqueue((neighbor, newPath));
                        }
                    }
                }
            }

            return new List<string>();
        }

        public List<string> Adjacent(string location)
        {
            if (targets.ContainsKey(location))
            {
                return targets[location];
            }
            return new List<string>();
        }

    }
}
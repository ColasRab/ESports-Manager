using System;
using System.Collections.Generic;
using ESportsManager.Maps;
using ESportsManager.Objects;
using Simulators;

class Program
{
    static void Main()
    {
        // --- Setup map ---
        Dust2 dust2 = new Dust2();
        dust2.LoadPositions();
        dust2.LoadTargets();

        // --- Setup players ---
        List<Player> players = new List<Player>
        {
            new Player("T Alice", 22, 85, 90),
            new Player("T Bob", 25, 80, 85),
            new Player("T Charlie", 20, 90, 88),
            new Player("T Diana", 23, 78, 92),
            new Player("T Ethan", 24, 82, 87),
            new Player("CT Fiona", 21, 88, 91),
            new Player("CT George", 26, 79, 84),
            new Player("CT Hannah", 22, 86, 89),
            new Player("CT Ian", 23, 81, 83),
            new Player("CT Jane", 24, 87, 90)
        };

        // --- Split into two teams ---
        List<Player> teamA = new List<Player>();
        List<Player> teamB = new List<Player>();

        for (int i = 0; i < players.Count; i++)
        {
            if (i < players.Count / 2)
                teamA.Add(players[i]);
            else
                teamB.Add(players[i]);
        }

        // --- Start Simulation ---
        CS_Simulator.Run(teamA, teamB, dust2);
    }
}

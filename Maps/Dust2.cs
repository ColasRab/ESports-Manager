using System;
using System.Collections.Generic;

namespace ESportsManager.Maps
{
    public class Dust2 : MapLoader
    { 
        private Dictionary<string, List<(string, int)>> positions = new Dictionary<string, List<(string, int)>>();
        private Dictionary<string, List<string>> targets = new Dictionary<string, List<string>>();

        public void LoadPositions()
        {
            AddEdge("T Spawn", "T Plat", 1);
            AddEdge("T Spawn", "Suicide", 1);
            AddEdge("T Spawn", "Outside Long", 1);
            AddEdge("T Plat", "Outside Tunnels", 1);
            AddEdge("Outside Tunnels", "Upper Tunnels", 1);
            AddEdge("Upper Tunnels", "B Close", 1);
            AddEdge("Upper Tunnels", "Lower Tunnels", 1);
            AddEdge("B Close", "No Man's Land", 1);
            AddEdge("No Man's Land", "B Default", 1);
            AddEdge("No Man's Land", "B Doors (Inside)", 1);
            AddEdge("B Default", "B Backside", 1);
            AddEdge("B Default", "B Doors (Inside)", 1);
            AddEdge("B Default", "Windows (Inside)", 1);
            AddEdge("B Backside", "Windows (Inside)", 1);
            AddEdge("B Doors (Inside)", "B Doors (Outside)", 1);
            AddEdge("Windows (Inside)", "Windows (Outside)", 1);
            AddEdge("Windows (Outside)", "B Doors (Outside)", 1);
            AddEdge("Windows (Outside)", "B Ramps", 1);
            AddEdge("B Doors (Outside)", "Windows (Outside)", 1);
            AddEdge("B Doors (Outside)", "B Ramps", 1);
            AddEdge("B Ramps", "CT Mid", 1);
            AddEdge("Lower Tunnels", "Mid Doors", 1);
            AddEdge("Suicide", "Top Mid", 1);
            AddEdge("Top Mid", "Mid", 1);
            AddEdge("Top Mid", "Catwalk", 2);
            AddEdge("Mid", "Mid Doors", 1);
            AddEdge("Mid", "Lower Tunnels", 1);
            AddEdge("Mid Doors", "CT Mid", 1);
            AddEdge("CT Mid", "CT Spawn", 1);
            AddEdge("CT Spawn", "CT Ramps", 1);
            AddEdge("CT Ramps", "A Cross", 1);
            AddEdge("Catwalk", "Cat", 1);
            AddEdge("Cat", "Stairs", 1);
            AddEdge("Stairs", "A Short", 1);
            AddEdge("A Short", "A Plat", 1);
            AddEdge("A Plat", "A Default", 1);
            AddEdge("Outside Long", "Long Doors (Inside)", 1);
            AddEdge("Outside Long", "Top Mid", 1);
            AddEdge("Long Doors (Inside)", "Long Doors (A Side)", 1);
            AddEdge("Long Doors (A Side)", "A Long", 1);
            AddEdge("A Long", "A Cross", 2);
            AddEdge("A Cross", "A Ramps", 1);
            AddEdge("A Ramps", "A Default", 1);
        }

        public void LoadTargets()
        {
            AddEdge("T Spawn", "T Plat");
            AddEdge("T Spawn", "Suicide");
            AddEdge("T Spawn", "Outside Long");
            AddEdge("T Plat", "Outside Tunnels");
            AddEdge("T Plat", "Upper Tunnels");
            AddEdge("Outside Tunnels", "Upper Tunnels");
            AddEdge("Upper Tunnels", "B Close");
            AddEdge("Upper Tunnels", "No Man's Land");
            AddEdge("Upper Tunnels", "Lower Tunnels");
            AddEdge("B Close", "No Man's Land");
            AddEdge("B Close", "B Default");
            AddEdge("B Close", "B Doors (Inside)");
            AddEdge("B Close", "Windows (Inside)");
            AddEdge("No Man's Land", "B Default");
            AddEdge("No Man's Land", "B Backside");
            AddEdge("No Man's Land", "B Doors (Inside)");
            AddEdge("B Default", "B Backside");
            AddEdge("B Default", "B Doors (Inside)");
            AddEdge("B Default", "Windows (Inside)");
            AddEdge("B Backside", "Windows (Inside)");
            AddEdge("B Backside", "B Doors (Inside)");
            AddEdge("B Doors (Inside)", "B Doors (Outside)");
            AddEdge("Windows (Inside)", "Windows (Outside)");
            AddEdge("Windows (Outside)", "B Doors (Outside)");
            AddEdge("Windows (Outside)", "B Ramps");
            AddEdge("Windows (Outside)", "CT Mid");
            AddEdge("B Doors (Outside)", "Windows (Outside)");
            AddEdge("B Doors (Outside)", "B Ramps");
            AddEdge("B Doors (Outside)", "CT Mid");
            AddEdge("B Ramps", "CT Mid");
            AddEdge("B Ramps", "CT Spawn");
            AddEdge("Lower Tunnels", "Mid Doors");
            AddEdge("Lower Tunnels", "Cat");
            AddEdge("Lower Tunnels", "Catwalk");
            AddEdge("Suicide", "Top Mid");
            AddEdge("Suicide", "Mid");
            AddEdge("Top Mid", "Mid");
            AddEdge("Top Mid", "CT Mid");
            AddEdge("Top Mid", "Catwalk");
            AddEdge("Mid", "Mid Doors");
            AddEdge("Mid", "Lower Tunnels");
            AddEdge("Mid", "Catwalk");
            AddEdge("Mid", "Cat");
            AddEdge("Mid Doors", "CT Mid");
            AddEdge("CT Mid", "CT Spawn");
            AddEdge("CT Mid", "CT Ramps");
            AddEdge("CT Spawn", "CT Ramps");
            AddEdge("CT Ramps", "A Cross");
            AddEdge("CT Ramps", "A Plat");
            AddEdge("Catwalk", "Cat");
            AddEdge("Catwalk", "Mid Doors");
            AddEdge("Catwalk", "CT Mid");
            AddEdge("Cat", "Stairs");
            AddEdge("Stairs", "A Short");
            AddEdge("A Short", "A Plat");
            AddEdge("A Short", "CT Ramps");
            AddEdge("A Short", "A Cross");
            AddEdge("A Short", "A Default");
            AddEdge("A Short", "A Ramps");
            AddEdge("A Plat", "A Default");
            AddEdge("Outside Long", "Long Doors (Inside)");
            AddEdge("Outside Long", "Top Mid");
            AddEdge("Outside Long", "Long Doors (A Side)");
            AddEdge("Long Doors (Inside)", "Long Doors (A Side)");
            AddEdge("Long Doors (Inside)", "A Long");
            AddEdge("A Long", "A Cross");
            AddEdge("A Long", "A Default");
            AddEdge("A Long", "A Ramps");
            AddEdge("A Long", "A Plat");
            AddEdge("A Cross", "A Ramps");
            AddEdge("A Ramps", "A Default");
        }
    }
}
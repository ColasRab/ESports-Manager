using ESportsManager.Objects;

namespace Simulators
{
    public class CS_Simulator
    {
        private List<ESportsManager.Objects.CS_Player> t = new List<ESportsManager.Objects.CS_Player>();
        private List<ESportsManager.Objects.CS_Player> ct = new List<ESportsManager.Objects.CS_Player>();
        private static Random rand = new Random();

        public void SetPlaybook_T_AllB()
        {
            foreach (var player in t)
            {
                player.AddPlaybookAction(new PlaybookAction(ActionType.MOVE, "T Spawn", "Upper Tunnels"));
                player.AddPlaybookAction(new PlaybookAction(ActionType.MOVE, "Upper Tunnels", "B Site"));
            }
        }

        public void SetPlaybook_CT_AllB()
        {
            foreach (var player in ct)
            {
                player.AddPlaybookAction(new PlaybookAction(ActionType.MOVE, "CT Spawn", "B Site"));
                player.AddPlaybookAction(new PlaybookAction(ActionType.DEFEND, "Upper Tunnels", "B Site"));
            }
        }


        public void PopulateTeamA(List<ESportsManager.Objects.Player> players)
        {
            t.Add(new ESportsManager.Objects.CS_Player(players[0], "T Spawn", null));
            t.Add(new ESportsManager.Objects.CS_Player(players[1], "T Spawn", null));
            t.Add(new ESportsManager.Objects.CS_Player(players[2], "T Spawn", null));
            t.Add(new ESportsManager.Objects.CS_Player(players[3], "T Spawn", null));
            t.Add(new ESportsManager.Objects.CS_Player(players[4], "T Spawn", null));
        }

        public void PopulateTeamB(List<ESportsManager.Objects.Player> players)
        {
            ct.Add(new ESportsManager.Objects.CS_Player(players[0], "CT Spawn", null));
            ct.Add(new ESportsManager.Objects.CS_Player(players[1], "CT Spawn", null));
            ct.Add(new ESportsManager.Objects.CS_Player(players[2], "CT Spawn", null));
            ct.Add(new ESportsManager.Objects.CS_Player(players[3], "CT Spawn", null));
            ct.Add(new ESportsManager.Objects.CS_Player(players[4], "CT Spawn", null));
        }

        private void ExecutePlaybook(CS_Player player)
        {
            int step = 0;
            bool stillHasActions = true;

            while (stillHasActions)
            {
                stillHasActions = false;

                Console.WriteLine($"\n⏱️ Step {step + 1}");

                foreach (var p in t.Concat(ct).ToList())
                {
                    var playbook = p.GetPlaybook();
                    if (step < playbook.Count)
                    {
                        stillHasActions = true;
                        var action = playbook[step];

                        if (action.Type == ActionType.MOVE)
                        {
                            Console.WriteLine($"🚶 {p.GetName()} moving from {action.From} to {action.To}");
                            p.SetPosition(action.To);
                        }
                        else if (action.Type == ActionType.DEFEND)
                        {
                            Console.WriteLine($"🛡️ {p.GetName()} defending {action.To} from {action.From}");
                            // mark position as defended
                        }
                    }
                }

                ResolveConflicts();

                if (t.Count == 0 || ct.Count == 0)
                {
                    AnnounceWinner();
                    return;
                }

                step++;
            }
        }


        private void ResolveConflicts()
        {
            foreach (var tPlayer in t.ToList())
            {
                foreach (var ctPlayer in ct.ToList())
                {
                    if (tPlayer.GetPosition() == ctPlayer.GetPosition())
                    {
                        Console.WriteLine($"⚔️ {tPlayer.GetName()} encounters {ctPlayer.GetName()} at {tPlayer.GetPosition()}!");

                        if (rand.Next(2) == 0)
                        {
                            Fight(tPlayer, ctPlayer);
                            if (ct.Contains(ctPlayer) && t.Contains(tPlayer))
                                Fight(ctPlayer, tPlayer);
                        }
                        else
                        {
                            Fight(ctPlayer, tPlayer);
                            if (t.Contains(tPlayer) && ct.Contains(ctPlayer))
                                Fight(tPlayer, ctPlayer);
                        }
                    }
                }
            }
        }


        public void Fight(CS_Player attacker, CS_Player defender)
        {
            int attackRoll = rand.Next(0, attacker.GetAccuracy() + attacker.GetQuickness());
            int defenseRoll = rand.Next(0, defender.GetAccuracy() + defender.GetQuickness());

            if (attackRoll > defenseRoll)
            {
                Console.WriteLine($"💀 {attacker.GetName()} eliminated {defender.GetName()}");
                if (t.Contains(defender)) t.Remove(defender);
                if (ct.Contains(defender)) ct.Remove(defender);
            }
            else
            {
                Console.WriteLine($"🛡️ {defender.GetName()} survived attack from {attacker.GetName()}");
            }
        }

        private void AnnounceWinner()
        {
            Console.WriteLine("\n✅ Round finished.");

            if (t.Count > 0 && ct.Count == 0)
                Console.WriteLine("🎉 Terrorists win!");
            else if (ct.Count > 0 && t.Count == 0)
                Console.WriteLine("🛡️ Counter-Terrorists win!");
            else
                Console.WriteLine("🤝 Round ends in a draw (both sides still have survivors).");
        }


        public void SimulateMatch()
        {
            Console.WriteLine("▶️ Starting round...\n");

            foreach (var p in t.Concat(ct).ToList())
            {
                ExecutePlaybook(p);

                // if a team is already wiped, stop simulating further
                if (t.Count == 0 || ct.Count == 0)
                    return;
            }

            // If loop ends naturally (no team fully eliminated mid-step), announce result
            AnnounceWinner();
        }


        public static void Run(List<Player> teamA, List<Player> teamB)
        {
            Console.WriteLine("Running CS Simulator...");
            
            // Create instance
            CS_Simulator sim = new CS_Simulator();

            sim.PopulateTeamA(teamA);
            sim.PopulateTeamB(teamB);

            // --- Set Playbooks: all players go B ---
            sim.SetPlaybook_T_AllB();
            sim.SetPlaybook_CT_AllB();

            sim.SimulateMatch();

            Console.WriteLine("CS Simulation completed.");
        }
    }
}
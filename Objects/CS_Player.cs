namespace ESportsManager.Objects
{
    public class CS_Player
    {
        private string name;
        private int age;
        private int accuracy;
        private int quickness;
        private string position = "";
private string target = "";
        
        private List<PlaybookAction> playbook = new List<PlaybookAction>();

        public CS_Player(Player player, string? position, string? target)
        {
            this.name = player.GetName();
            this.age = player.GetAge();
            this.accuracy = player.GetAccuracy();
            this.quickness = player.GetQuickness();
            this.position = position;
            this.target = target;
        }

        public void AddPlaybookAction(PlaybookAction action)
        {
            playbook.Add(action);
        }

        public List<PlaybookAction> GetPlaybook()
        {
            return playbook;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {age}, Accuracy: {accuracy}, Quickness: {quickness}, Position: {position}, Target: {target}");
        }

        public string GetName()
        {
            return name;
        }

        public void SetPosition(string position)
        {
            this.position = position;
        }

        public void SetTarget(string target)
        {
            this.target = target;
        }

        public string GetPosition()
        {
            return position;
        }

        public string GetTarget()
        {
            return target;
        }

        public int GetAccuracy()
        {
            return accuracy;
        }

        public int GetQuickness()
        {
            return quickness;
        }
    }
}
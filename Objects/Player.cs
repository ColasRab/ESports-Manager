namespace ESportsManager.Objects
{
    public class Player
    {
        private string name;
        private int age;
        private int accuracy;
        private int quickness;

        public Player(string name, int age, int accuracy, int quickness)
        {
            this.name = name;
            this.age = age;
            this.accuracy = accuracy;
            this.quickness = quickness;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {age}, Accuracy: {accuracy}, Quickness: {quickness}");
        }

        public string GetName() => name;
        public int GetAge() => age;
        public int GetAccuracy() => accuracy;
        public int GetQuickness() => quickness;
    }
}
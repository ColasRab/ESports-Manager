namespace ESportsManager.Objects
{
    public enum ActionType
    {
        MOVE,
        DEFEND
    }

    public class PlaybookAction
    {
        public ActionType Type { get; }
        public string From { get; }
        public string To { get; }

        public PlaybookAction(ActionType type, string from, string to)
        {
            Type = type;
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return $"{Type} {From} -> {To}";
        }
    }
}
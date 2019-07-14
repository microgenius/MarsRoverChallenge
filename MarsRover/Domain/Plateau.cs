namespace MarsRover.Domain
{
    public class Plateau
    {
        public int MinXPosition { get; set; }
        public int MinYPosition { get; set; }
        public int MaxXPosition { get; set; }
        public int MaxYPosition { get; set; }

        public override string ToString() => $"MinXPos: {MinXPosition}, MaxXPos: {MaxXPosition}, MinYPos:{MinYPosition}, MaxYPos: {MaxYPosition}";
    }
}
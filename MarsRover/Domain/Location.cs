using System;

namespace MarsRover.Domain
{
    public class Location
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        private Direction _direction;
        public Direction Direction
        {
            get { return _direction; }
            set { this._direction = value; }
        }

        public void ParseToDirection(char directionString) => this._direction = new Direction(directionString);

        public override string ToString() => $"{XPosition} {YPosition} {Direction}";
    }
}
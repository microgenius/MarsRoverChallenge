using System;
using MarsRover.Domain.Base;

namespace MarsRover.Domain
{
    public class Direction
    {
        private readonly CircularList<eDirection> _directionMap = new CircularList<eDirection>()
        {
            eDirection.North,
            eDirection.West,
            eDirection.South,
            eDirection.East
        };

        private eDirection _currentDirection;

        public eDirection CurrentDirection => _currentDirection;

        public Direction(char directionString) 
        {
            var direction = (eDirection) directionString;
            this._currentDirection = direction;

            var currentDirectionPosition = this._directionMap.FindIndex(value => value == this._currentDirection);
            this._directionMap.Position = currentDirectionPosition;
        }

        public void TurnLeft() => this._currentDirection = this._directionMap.Next();
        
        public void TurnRight() => this._currentDirection = this._directionMap.Previous();

        public override string ToString() => $"{(char)_currentDirection}";
    }

    public enum eDirection
    {
        West = 'W',
        East = 'E',
        North = 'N',
        South = 'S'
    }
}
using System.Collections.Generic;

namespace MarsRover.Domain.Base
{
    public class CircularList<T> : List<T>
    {
        private int _position = 0;

        public int Position
        {
            set => _position = value;
        }

        public T Previous()
        {
            _position--;
            if (_position < 0) { _position = this.Count - 1; }
            
            return this[_position];
        }
        
        public T Next()
        {
            _position++;
            if (_position >= this.Count) { _position = 0; }

            return this[_position];
        }
    }
}
using System;
using CircusDataAccessLibrary.Helpers.Interfaces;

namespace CircusDataAccessLibrary.Helpers.Implementations
{
    public class IntIdGenerator : IIdGenerator<int>
    {
        private readonly Random _random;
        public IntIdGenerator()
        {
            _random = new Random();
        }
        
        public int Next()
        {
            return _random.Next();
        }
    }
}
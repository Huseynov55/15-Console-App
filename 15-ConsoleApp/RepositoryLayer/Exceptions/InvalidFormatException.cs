using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Exceptions
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string message) : base(message) { }
        
    }
}

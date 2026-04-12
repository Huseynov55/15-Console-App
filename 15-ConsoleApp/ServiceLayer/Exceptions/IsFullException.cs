using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Exceptions
{
    public class IsFullException : Exception
    {
        public IsFullException(string message) : base(message) { }
    }
}

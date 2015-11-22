using System;
using System.Collections.Generic;

namespace Scratch.Data
{
    public class DataException : Exception, ISignal
    {
        public Enums.Andons Andon { get; set; }

        public List<string> Messages { get; set; }

        public DataException(string message)
        {
            Messages = new List<string> { message };
        }
    }
}

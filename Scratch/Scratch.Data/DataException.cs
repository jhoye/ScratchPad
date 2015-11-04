using System;

namespace Scratch.Data
{
    public class DataException : Exception
    {
        private string ContextualMessage { get; set; }

        public DataException(string contextualMessage)
        {
            ContextualMessage = contextualMessage;
        }
    }
}

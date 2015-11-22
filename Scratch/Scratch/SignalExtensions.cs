using System;
using System.Collections.Generic;

namespace Scratch
{
    public static class SignalExtensions
    {
        public static void SetSignal(this ISignal obj, IEnumerable<string> messages, Enums.Andons andon = Enums.Andons.Green)
        {
            if (obj.Messages == null)
            {
                obj.Messages = new List<string>();
            }

            obj.Messages.AddRange(messages);

            obj.Andon = andon;
        }

        public static void SetSignal(this ISignal obj, string message, Enums.Andons andon = Enums.Andons.Green)
        {
            obj.SetSignal(new List<string> { message }, andon);
        }

        public static void SetSignal(this ISignal obj, Exception exception)
        {
            obj.SetSignal(exception.Message, Enums.Andons.Red);
        }
    }
}

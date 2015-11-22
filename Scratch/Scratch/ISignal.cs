using System.Collections.Generic;

namespace Scratch
{
    public interface ISignal
    {
        Enums.Andons Andon { get; set; }

        List<string> Messages { get; set; }
    }
}

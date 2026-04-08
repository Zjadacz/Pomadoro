using System;
using System.Collections.Generic;
using System.Text;

namespace Pomadoro
{
    public interface IDelayProvider
    {
        Task Delay(TimeSpan timeSpan);
    }
}

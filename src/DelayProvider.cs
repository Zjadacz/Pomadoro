using System;
using System.Collections.Generic;
using System.Text;

namespace Pomadoro
{
    internal class DelayProvider : IDelayProvider
    {
        public Task Delay(TimeSpan timeSpan) => Task.Delay(timeSpan);
    }
}

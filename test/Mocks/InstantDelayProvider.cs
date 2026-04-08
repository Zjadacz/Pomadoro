using Pomadoro;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomadoroTests.Mocks
{
    internal class InstantDelayProvider : IDelayProvider
    {
        public Task Delay(TimeSpan timeSpan) => Task.CompletedTask;
    }
}

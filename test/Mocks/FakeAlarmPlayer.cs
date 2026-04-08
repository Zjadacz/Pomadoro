using Pomadoro;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomadoroTests.Mocks
{
    internal class FakeAlarmPlayer : IAlarmPlayer
    {
        public int PlayCount = 0;

        public void PlaySound() => PlayCount++;
    }
}

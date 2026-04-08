using Pomadoro;
using PomadoroTests.Mocks;
using System.Timers;

namespace PomadoroTests
{
    [TestClass]
    public sealed class PomadoroTimerTests
    {
        [TestMethod]
        public async Task RunPhase_ShouldCallPlaySoundAndChangeTitle_WhenFinished()
        {
            // Arrange
            var console = new FakeConsole();
            var alarm = new FakeAlarmPlayer();
            var time = new InstantDelayProvider();

            var timer = new PomadoroTimer(1, 1, console, alarm, time);

            // Act
            await timer.RunPhase("Work", TimeSpan.FromSeconds(2), ConsoleColor.Red);

            // Assert
            Assert.AreEqual(1, alarm.PlayCount);
            Assert.AreEqual("Work Phase finished!", console.Title);
        }

        [TestMethod]
        public async Task StartRunOnce_ShouldHaveTwoPhases_WorkAndBreak()
        {
            // Arrange
            var console = new FakeConsole();
            var alarm = new FakeAlarmPlayer();
            var time = new InstantDelayProvider();

            var timer = new PomadoroTimer(1, 1, console, alarm, time);

            // Act
            await timer.Start(true);

            // Assert
            Assert.HasCount(2, timer.PhaseCounter);
            Assert.AreEqual(1, timer.PhaseCounter["Work"]);
            Assert.AreEqual(1, timer.PhaseCounter["Break"]);
        }
    }
}

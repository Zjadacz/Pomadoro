using Pomadoro;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomadoroTests.Mocks
{
    internal class FakeConsole : IConsole
    {
        public ConsoleColor ForegroundColor { get; set; }
        public bool CursorVisible { get; set; }
        public string Title { get; set; }

        public void WriteLine(string text) { }
        public void Write(string text) { }
    }
}

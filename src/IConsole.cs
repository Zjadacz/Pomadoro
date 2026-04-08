using System;
using System.Collections.Generic;
using System.Text;

namespace Pomadoro
{
    public interface IConsole
    {
        void WriteLine(string text);
        void Write(string text);
        ConsoleColor ForegroundColor { set; }
        bool CursorVisible { set; }
        string Title { set; }
    }

    public class ConsoleAdapter : IConsole
    {
        public ConsoleColor ForegroundColor
        {
            set => Console.ForegroundColor = value;
        }

        public bool CursorVisible 
        {
            set => Console.CursorVisible = value;
        }

        public string Title 
        {
            set => Console.Title = value;
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}

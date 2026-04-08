using Pomadoro;
using System.Collections;
using System.Text;

int workTime = 25;
int breakTime = 5;

if (args.Length > 0)
{
    if (!int.TryParse(args[0], out workTime))
    {
        DisplayHelp("Error: Work time parameter should be a simple number, f.e. '12'.");
        return;
    }
}

if (args.Length > 1)
{
    if (!int.TryParse(args[1], out breakTime))
    {
        DisplayHelp("Error: Break time parameter should be a simple number, f.e. '8'.");
        return;
    }
}

if (args.Length > 2)
{
    DisplayHelp("Error: Too many parameters.");
    return;
}

var timer = new PomadoroTimer(workTime, breakTime);
await timer.Start();

static void DisplayHelp(string message = "")
{
    var sb = new StringBuilder();

    if (!string.IsNullOrEmpty(message))
    {
        sb.AppendLine(message);
        sb.AppendLine();
    }

    sb.AppendLine("Pomadoro.exe - use pomodoro technice from your command-line console.");
    sb.AppendLine("Usage: pomodoro [worktime] [breaktime]");
    sb.AppendLine("- worktime : (default 25 minutes) working time in simple number format, f.e. '12'.");
    sb.AppendLine("- breaktime: (default  5 minutes) breajk time in simple number format, f.e. '2'.");

    Console.WriteLine(sb.ToString());
}




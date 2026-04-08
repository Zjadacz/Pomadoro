# Pomadoro

**Pomadoro** is a simple console-based Pomodoro timer built with .NET Core. It helps you manage focused work sessions and breaks using the Pomodoro Technique.  

## Features

- Simple and lightweight console application  
- Customizable work and break durations  
- Audible alert when a session or break ends  
- Easy to run with command-line arguments  

## Requirements

- [.NET Core](https://dotnet.microsoft.com/download) installed on your machine  

## Usage

Run the application from the command line with two arguments:  

```bash
Pomadoro.exe <workTime> <breakTime>

Where:

<workTime>  – duration of the work session in minutes
<breakTime> – duration of the break session in minutes

Example:

Pomadoro.exe 25 5
```

This starts a 25-minute work session followed by a 5-minute break.

## How It Works
1. Start the application with the desired work and break durations.
2. The timer begins counting down the work session.
3. When the work session ends, an audible alert plays.
4. The break session automatically begins and counts down.
5. Another audible alert plays when the break ends.
6. Repeat the cycle as needed.

## Notes
The timer runs in the console, so keep the window open during sessions.
Sound notifications depend on your system’s audio settings.

## License

This project is licensed under the MIT License. See the LICENSE
 file for details.

# Kurukuru
[![Build-Development](https://github.com/mayuki/Kurukuru/workflows/Build-Development/badge.svg)](https://github.com/mayuki/Kurukuru/actions)

> Terminal Spinner library for .NET platform (.NET Framework, .NET Standard, .NET 5). strongly inspired by [cli-spinners](https://github.com/sindresorhus/cli-spinners), [ora](https://github.com/sindresorhus/ora), [CLISpinner](https://github.com/kiliankoe/CLISpinner).

![](Resources/Screen-Demo-01.gif)

## Features
### Aware non-Unicode codepage on Windows environment.
When running on terminal using non-Unicode codepages (e.g. CP437:EN-US, CP932:JA-JP), the library will render using ASCII-characters spinner by default.

- fig. Left:Command Prompt (CP932) / Right:mintty (UTF-8 on Linux)<br />![](Resources/Screen-Demo-02.gif) 

**NOTE:** Sadly, today's almost Windows are configured as using non-Unicode (UTF-8) code page and "Command Prompt" doesn't support font fallback yet.☹ If you want to see non-ASCII spinners, you can change the code page either by `System.Console.OutputEncoding = System.Text.Encoding.UTF8` or by running
 `chcp 65001` command and then use [ConEmu](https://conemu.github.io/) or [mintty](https://mintty.github.io/) to display the fallback font. 

- See: [Screenshot: cmd vs ConEmu on Windows 10(EN-US)](Resources/CmdAndConEmu.png)

### Disable spinner automatically when running on a non-interactive context in which stdout is redirected.

For example, you can see just a result text when runs on CI.

## Install

### Package Manager Console
```
Install-Package Kurukuru
```

### **dotnet** command
```
dotnet add package Kurukuru
```


## Usage
Just add `using Kurukuru;` then call `Spinner.Start` with some delegate. 

```csharp
Spinner.Start("Processing...", () =>
{
    Thread.Sleep(1000 * 3);
    
    // MEMO: If you want to show as failed, throw a exception here.
    // throw new Exception("Something went wrong!");
});

Spinner.Start("Stage 1...", spinner =>
{
    Thread.Sleep(1000 * 3);
    spinner.Text = "Stage 2...";
    Thread.Sleep(1000 * 3);
    spinner.Fail("Something went wrong!");
});
```

You can also use async method pattern. Use `StartAsync` method.

```csharp
await Spinner.StartAsync("Processing...", async () =>
{
    await Task.Delay(1000 * 3);
    
    // MEMO: If you want to show as failed, throw a exception here.
    // throw new Exception("Something went wrong!");
});

await Spinner.StartAsync("Stage 1...", async spinner =>
{
    await Task.Delay(1000 * 3);
    spinner.Text = "Stage 2...";
    await Task.Delay(1000 * 3);
    spinner.Fail("Something went wrong!");
});
```

## API
### `Kurukuru.Spinner` class
#### Static Members
- `Start` / `StartAsync`: Create and start new spinner. And it waits specified action.
    - `void Start(string text, Action<Spinner> action, Pattern pattern = null, Pattern fallbackPattern = null)`
    - `void Start(string text, Action<Spinner> action, Pattern pattern = null, Pattern fallbackPattern = null)`
    - `Task StartAsync(string text, Func<Task> action, Pattern pattern = null, Pattern fallbackPattern = null)`
    - `Task StartAsync(string text, Func<Spinner, Task> action, Pattern pattern = null, Pattern fallbackPattern = null)`
        - `text`: a text to display while running action.
        - `action`: a long-running action.
        - `patterns`: Use spinner pattern (see `Patterns` class). Default value is `Patterns.Dot`. You can find a pattern you like in [the preview of cli-spinners](http://jsfiddle.net/sindresorhus/2eLtsbey/embedded/result/).
        - `fallbackPattern`: Use spinner pattern if console's codepage is non-Unicode. Default value is `Patterns.Line`.

#### Instance Methods
- `Stop`: Stop spinner and show a result if needed.
    - `Stop(string text = null, string symbol = null, ConsoleColor? color = null)`
    - `Stop(string text, string symbol, ConsoleColor? color, string terminator)`
- `Success`: Show result as ✔ success. (equivalent to `Stop` method)
- `Fail`: Show result as ✖ failure. (equivalent to `Stop` method)
- `Warning`: Show result as ⚠ warning. (equivalent to `Stop` method)
- `Info`: Show result as ℹ information. (equivalent to `Stop` method)

#### Instance Properties
- `Text`: Get or set a text to display while running action.
- `Color`: Get or set a color of the spinner. (not for text)

## Related

- [cli-spinners](https://github.com/sindresorhus/cli-spinners): Spinners for use in the terminal (node.js)
- [ora](https://github.com/sindresorhus/ora): Elegant terminal spinner (node.js)
- [CLISpinner](https://github.com/kiliankoe/CLISpinner): Swifty Terminal Spinner

## License

MIT License.

# Kurukuru

> Terminal Spinner library for .NET Core/Standard. strongly inspired by [cli-spinners](https://github.com/sindresorhus/cli-spinners), [ora](https://github.com/sindresorhus/ora), [CLISpinner](https://github.com/kiliankoe/CLISpinner).

## Features
- Aware non-Unicode codepage on Windows environment.
    - When running on terminal using non-Unicode codepages (e.g. CP932), the library will render using fallback characters. 

## Install

```
Install-Package Kurukuru
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

You can also use async method pattern.

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

## Related

- [cli-spinners](https://github.com/sindresorhus/cli-spinners): Spinners for use in the terminal (node.js)
- [ora](https://github.com/sindresorhus/ora): Elegant terminal spinner (node.js)
- [CLISpinner](https://github.com/kiliankoe/CLISpinner): Swifty Terminal Spinner

## License

MIT License.
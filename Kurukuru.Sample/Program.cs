using System;
using System.Threading.Tasks;

namespace Kurukuru.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            using (var spinner = new Spinner("Initializing...", Patterns.Dots12))
            {
                spinner.Start();
                await Task.Delay(2000);
                spinner.Succeed();
            }

            await Spinner.StartAsync("ユーザー Alice でログインを試みています…", async spinner =>
            {
                await Task.Delay(1000);
                spinner.Text = "こんにちは Alice!";
            });


            await Spinner.StartAsync("Executing some heavy task...", async () =>
            {
                await Task.Delay(3000);
                throw new Exception();
            });

        }
    }
}

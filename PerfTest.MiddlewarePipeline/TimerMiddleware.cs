using System;
using System.Diagnostics;

namespace PerftTest.MiddlewarePipeline
{
    public class TimerMiddleware : IMiddleware
    {
        public void Execute(Command command, Action<Command> next)
        {
            var timer = Stopwatch.StartNew();
            Console.WriteLine($"[INFO] - Início - {DateTime.Now:HH:mm:ss}");

            try
            {
                next(command);
            }
            finally
            {
                timer.Stop();
            }

            Console.WriteLine($"[INFO] - Fim - {DateTime.Now:HH:mm:ss} - Tempo decorrido: {timer.ElapsedMilliseconds} ms");
        }
    }
}

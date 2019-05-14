using System;
using System.Diagnostics;

namespace PerftTest.MiddlewarePipeline
{
    public class LoggingMiddleware : IMiddleware
    {
        public void Execute(Command command, Action<Command> next)
        {
            Console.WriteLine($"[LOG] - Início - {command.GetType()}");

            next(command);

            Console.WriteLine($"[LOG] - Fim - {command.GetType()}");
        }
    }
}

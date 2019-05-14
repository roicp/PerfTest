using System;

namespace PerftTest.MiddlewarePipeline
{
    public interface IMiddleware
    {
        void Execute(Command command, Action<Command> next);
    }
}

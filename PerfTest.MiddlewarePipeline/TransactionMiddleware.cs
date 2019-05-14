using System;
using System.Transactions;

namespace PerftTest.MiddlewarePipeline
{
    public class TransactionMiddleware : IMiddleware
    {
        public void Execute(Command command, Action<Command> next)
        {
            using (var ts = new TransactionScope())
                next(command);
        }
    }
}

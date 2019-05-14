using System;
using System.Collections.Generic;
using System.Linq;

namespace PerftTest.MiddlewarePipeline
{
    public class Pipeline
    {
        private readonly Lazy<Action<Command>> _middlewareChain;

        public Pipeline(params IMiddleware[] middlewares)
        {
            _middlewareChain = new Lazy<Action<Command>>(() => BuildChain(middlewares.Reverse()));
        }

        private static Action<Command> BuildChain(IEnumerable<IMiddleware> middlewares)
        {
            Action<Command> chain = command => { };

            foreach (var middleware in middlewares)
            {
                var temp = chain;

                chain = command => middleware.Execute(command, temp);
            }

            return chain;
        }

        public virtual void Handle<T>(T command) where T : Command
        {
            _middlewareChain.Value(command);
        }
    }
}

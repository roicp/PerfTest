using System;

namespace PerftTest.MiddlewarePipeline
{
    public class CommandHandleMiddleware : IMiddleware
    {
        public void Execute(Command command, Action<Command> next)
        {
            var cadastrarUsuarioHandler = new CadastrarUsuarioHandler();
            cadastrarUsuarioHandler.Handle((CadastrarUsuario)command);
        }
    }
}

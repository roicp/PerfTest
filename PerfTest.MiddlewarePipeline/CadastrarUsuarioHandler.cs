using System;

namespace PerftTest.MiddlewarePipeline
{
    public class CadastrarUsuarioHandler : IHandler<CadastrarUsuario>
    {
        public void Handle(CadastrarUsuario message)
        {
            Console.WriteLine($"Cadastrando usuário {message.Nome}");
        }
    }
}

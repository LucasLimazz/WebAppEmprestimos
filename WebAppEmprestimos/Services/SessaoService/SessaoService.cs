using WebAppEmprestimos.Models;

namespace WebAppEmprestimos.Services.SessaoService
{
    public class SessaoService : ISessaoInterface
    {
        private readonly IHttpContextAccessor _contextAcessor;
        public SessaoService(IHttpContextAccessor acessor)
        {
         
        }

        public UsuarioModel BuscarSessao()
        {
            throw new NotImplementedException();
        }

        public void CriarSessao(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }

        public void RemoveSessao()
        {
            throw new NotImplementedException();
        }
    }
}

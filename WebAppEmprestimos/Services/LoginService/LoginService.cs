using WebAppEmprestimos.Dto;
using WebAppEmprestimos.Models;

namespace WebAppEmprestimos.Services.LoginService
{
    public class LoginService : ILoginInterface
    {
        public Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto)
        {
            throw new NotImplementedException();
        }
    }
}

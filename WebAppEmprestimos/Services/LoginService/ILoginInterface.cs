using WebAppEmprestimos.Dto;
using WebAppEmprestimos.Models;

namespace WebAppEmprestimos.Services.LoginService
{
    public interface ILoginInterface
    {
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto);


    }
}

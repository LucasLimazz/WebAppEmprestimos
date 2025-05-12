namespace WebAppEmprestimos.Services.SenhaService
{
    public interface ISenhaInterfaceBase
    {
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
    }
}
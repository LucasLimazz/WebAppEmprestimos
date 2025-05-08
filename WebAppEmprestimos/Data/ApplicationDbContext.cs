using Microsoft.EntityFrameworkCore;
using WebAppEmprestimos.Models;

namespace WebAppEmprestimos.Data 

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  
        {
        } 
        
        public DbSet<EmprestimosModel> Emprestimos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}

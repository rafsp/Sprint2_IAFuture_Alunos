using Microsoft.EntityFrameworkCore;
using Sprint2.Models;

namespace Sprint2.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<FeedbackCliente> Feedbacks { get; set; }
        public DbSet<InteracaoCliente> Interacoes { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<ResultadoIa> Resultados { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {


        }

    }
}


namespace N_PlusOneProblem.Context
{
    internal class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<ArrecadacaoEntity> Arrecadacoes { get; set; }
        public DbSet<UnidadeFederativaEntity> UnidadesFederativas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}

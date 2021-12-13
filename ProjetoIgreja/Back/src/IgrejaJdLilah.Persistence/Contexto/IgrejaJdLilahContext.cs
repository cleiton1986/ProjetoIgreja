using IgrejaJdLilah.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace IgrejaJdLilah.Persistence.Contexto
{
    public class IgrejaJdLilahContext: DbContext
    {   
        public IgrejaJdLilahContext (DbContextOptions<IgrejaJdLilahContext> options)
            : base(options) { }
         public DbSet<Contato> Contatos { get; set; }
         public DbSet<Evento> Eventos { get; set; }
         public DbSet<Endereco> Enderecos { get; set; }
         public DbSet<Lote> Lote { get; set; }
         public DbSet<Palestrante> Palestrantes { get; set; }         
        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //Aqui informo que essa é a classe de junçao
        //Entre o Evento e Palestrante que são associado pelo os id
        //de cada tabela
           modelBuilder.Entity<PalestranteEvento>()
              .HasKey(pe => new {pe.EventoId, pe.PalestranteId});

           //Quando uma classe se relaciona com varias outras classe
           //Contendo id das mesmas, o entity não deleta em cascata os 
           //Os dados relecionado aos cadastrados nessas tabelas

           //Para dada evento que tenha uma ou mais redeSocial
           //E rede tem um ou mais evento
           //Pode ser deletada em cascata

            //Ou seja, Deletou o evento que possoua rede social, faça o delete
            //cascateado  deletando a rede social
            modelBuilder.Entity<Evento>()
              .HasMany(e => e.RedeSociais)
              .WithOne(rs => rs.Evento)
              .OnDelete(DeleteBehavior.Cascade);

            //Ou seja, Deletou o Palestrante que possoua rede social, faça o delete
            //cascateado deletando a rede social
            modelBuilder.Entity<Palestrante>()
              .HasMany(p => p.RedeSociais)
              .WithOne(rs => rs.Palestrante)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
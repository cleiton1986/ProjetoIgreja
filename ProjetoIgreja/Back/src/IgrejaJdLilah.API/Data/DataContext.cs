using IgrejaJdLilah.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IgrejaJdLilah.API.Data
{
    public class DataContext: DbContext
    {   
        public DataContext (DbContextOptions<DataContext> options) : base(options) {}
         public DbSet<Evento> Eventos { get; set; } 
    }
}
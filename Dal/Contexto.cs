using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SegundoParcial.Entidades;

namespace SegundoParcial.Dal
{
    public class Contexto : DbContext
    {
        public DbSet<Llamadas> Llamadas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\SegundoParcialDb");
        }
    }
}

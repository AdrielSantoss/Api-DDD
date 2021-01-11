using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MyContext: DbContext //Classe que irá receber as entidades que está no Domain e vai fazer um "conjunto" com o EntityFramework
    {
        public DbSet<UserEntity> Users { get; set; }
        
        public MyContext(DbContextOptions<MyContext> options ): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "admin@gmail.com",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                });

            modelBuilder.Entity<UserEntity>(new UserMap().Configure); //quando criar o modelo, o mapeamento/configurações será realizado
        
        }
    }
}

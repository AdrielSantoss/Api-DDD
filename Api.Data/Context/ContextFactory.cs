using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    class ContextFactory : IDesignTimeDbContextFactory<MyContext> //Cria em tempo de design um conexão com banco de dados para que possamos criar as tabelas
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar as migrations
           var connectionString = "Data Source=./api.db";
           // var connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=api;Integrated Security=SSPI"; 
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.UseSqlite(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}

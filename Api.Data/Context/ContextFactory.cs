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
            //var connectionString = "Data Source=api.db"; sqlite
            var connectionString = "Server=.\\SQLEXPRESS2017;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=123";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}

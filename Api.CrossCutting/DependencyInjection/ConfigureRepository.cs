using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            //Quando é repositório é nível de escopo, usamos AddScoped
            //Typeof: retorna o tipo 
            //<>: é necessário pois a classe e a interface esperam um genéric (tipo genérico <T>)
            //Mesma coisa dos services, quando IRepository for inicializado será feito uma instancia da classe BaseRepository

            serviceCollection.AddDbContext<MyContext>(
            options => options.UseSqlite("Data Source=api.db")
            //options => options.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=api;Integrated Security=SSPI") 

            );

        }
    }
}

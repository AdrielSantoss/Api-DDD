using Domain.Services.User;
using Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    { 
        //IMPORTANTE:Criei esta injeção de dependencia, pois o projeto tem tendencia a crescer, assim fica mais facil realziar manutenções
        //Poderia ter feito essas configurações dentro do Startup.cs da aplicação
        //Porém, para realizar estas configurações no startup, a camada de aplicação teria que utilizar dependencias da camada Data, isso não é boa prática no modelo DDD


        public static void ConfigureDependenciesService(IServiceCollection serviceCollecion)
        {
            serviceCollecion.AddTransient<IUserService, UserService>();
            //AddTransient: Para cada uso da interface IUserService será criado uma NOVA instância de UserService
            //AddScoped: Se em 10 métodos for necessário utilizar a interface IUserService será usado a MESMA instância de UserService, esta configuração é muito utilizada para evitar LOOPINGS infinitos
            //AddSingleton: Iniciou a aplicação no servidor, jamais mudará, inica somente uma vez, normalmente este é o mais problemático


        }
    }
}

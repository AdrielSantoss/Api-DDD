using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T:BaseEntity //Criando Repository genérico;  dentro do T será injetado uma classe que tenha herança de "BaseEntity"    
    {//lembrando: Interface é como se fosse um contrato uma assinatura dos métodos
        Task<T> insertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync(); //trazendo uma lista de usuário (por isso o IEnumerable)
        Task<bool> ExistsAsync(Guid id);

    }
}

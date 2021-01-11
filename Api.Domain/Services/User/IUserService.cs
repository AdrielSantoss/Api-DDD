using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.User
{
    public interface IUserService //Interface de regras de negócio
    {// NÃO CONFUNDIR COM INTERFACE DE REPOSITORY QUE É A INTERFACE QUE SE COMUNICARÁ COM O BANCO DE DADOS
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> Post(UserEntity user);
        Task<UserEntity> Put(UserEntity user);
        Task<bool> Delete(Guid id);

    }
}

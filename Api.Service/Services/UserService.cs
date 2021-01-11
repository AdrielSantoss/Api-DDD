using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.User;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        } //

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            //dentro destes métodos do service pode aplicar as regras de negócios e validações
            if(user.Name == "teste")
            {
                return null; //fiz uma validação, como exemplo.
            }
            // ou seja, aqui no UserService.cs implementados as regras de negocios
            return await _repository.insertAsync(user);

        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}

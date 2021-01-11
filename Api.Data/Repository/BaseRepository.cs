using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly MyContext _context;
        private DbSet<T>  _dataSet;
        public BaseRepository(MyContext context)
        {
            _context = context; //disponibilizando o context para toda a classe
            _dataSet = _context.Set<T>(); 
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.id.Equals(id));
                if (result == null)
                {
                    return false;
                }

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.id.Equals(id)); //verificando se o usuário existe

        }

        public async Task<T> insertAsync(T item)
        {
            try
            {
                if(item.id == Guid.Empty)
                {
                    item.id = Guid.NewGuid();  //o .net vai atribuir automaticamente um novo guid 
                    
                }
                item.CreateAt = DateTime.UtcNow;
                _dataSet.Add(item);

                await _context.SaveChangesAsync(); //commit no banco de dados (explicação do castel sobre commit e rollback)

            }
            catch (Exception e)
            {

                throw e;
            }

            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.id.Equals(id));
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();  //select sem where, retornando todos os usuários
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.id.Equals(item.id));
                if(result == null)
                {
                    return null;
                }

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt; //permanecendo a data criada

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return item;
        }
    }
}

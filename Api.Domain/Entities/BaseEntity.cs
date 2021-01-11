using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key] //setando id como Chave primária
        public Guid id { get; set; } //Guid é um id gerado automaticamente com letras e número aujosd-hasufhdsd-jof3w0943-4205tfdju <- tipo isso

        private DateTime? _createAt; 

        public DateTime? CreateAt //nome da Propriedade do banco de dados
        {
            get { return _createAt; }
            set { _createAt = (value == null?DateTime.UtcNow: value); } //caso o valor venha nulo é armazenado o valor do "servidor"
        }
        public DateTime? UpdateAt { get; set; } 

    }
}

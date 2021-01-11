using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class UserDtoCreateResult
    { //Dto para retornar para o usuário
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public DateTime CreateAt { get; set; }
         
    }
}

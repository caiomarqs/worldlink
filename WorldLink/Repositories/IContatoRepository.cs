using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldLink.Models;

namespace WorldLink.Repositories
{
    public interface IContatoRepository: IGenericRepository<Contato>
    {
        public Contato FindByEmail(string email);
    }
}

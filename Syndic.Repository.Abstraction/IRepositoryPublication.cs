using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Repository.Abstraction
{
    public interface  IRepositoryPublication<t> :IRepository<t>
    {
        public IEnumerable<t> rechercheParDossier(int id);
    }
}

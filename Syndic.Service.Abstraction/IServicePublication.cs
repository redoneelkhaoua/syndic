using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Service.Abstraction
{
    public interface IServicePublication<t>:IService<t>
    {
        public IEnumerable<t> rechercheParDossier(int id);
    }
}

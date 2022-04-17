using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Service.Abstraction
{
    public interface IService<Model>
    {

        public IEnumerable<Model> getAll();
        public Model findById(int id);
        public Model create(Model model);
        public void delete(int id);
        public void update(int id, Model model);

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Repository.Abstraction
{
    public interface IRepository<Model>
    {
        public IEnumerable<Model> rechercherTout();
        public Model rechercheParId(int id);
        public void creer(Model model);
        public void suprimer(int id);
        public void modifier(int id, Model model);

    }
}

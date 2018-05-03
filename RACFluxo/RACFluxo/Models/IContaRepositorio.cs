using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACFluxo.Models
{
    interface IContaRepositorio
    {
        IEnumerable<Conta> GetAll();
        IEnumerable<Conta> GetByTipo(string tipo);
        Conta Get(int id);
        bool Add(Conta item);
        void Remove(int id);
        bool Update(Conta item);
    }
}

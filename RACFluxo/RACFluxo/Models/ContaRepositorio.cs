using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RACFluxo.Models
{
    public class ContaRepositorio : IContaRepositorio
    {
        private List<Conta> ContaList = new List<Conta>();

        public ContaRepositorio()
        {
            Add(new Conta { IdConta = 1, Nome = "TELEFONE", NomeResumido = "TEL", Tipo = "D"});
            Add(new Conta { IdConta = 2, Nome = "ENTRETENIMENTO", NomeResumido = "ENT", Tipo = "D" });
            Add(new Conta { IdConta = 3, Nome = "ENERGIA", NomeResumido = "ENE", Tipo = "D" });
            Add(new Conta { IdConta = 4, Nome = "SALARIO", NomeResumido = "SAL", Tipo = "C" });
            Add(new Conta { IdConta = 5, Nome = "FARMACIA", NomeResumido = "FAR", Tipo = "D" });
            Add(new Conta { IdConta = 6, Nome = "CARRO", NomeResumido = "CAR", Tipo = "D" });
            Add(new Conta { IdConta = 7, Nome = "LANCHONETE", NomeResumido = "LAN", Tipo = "D" });
        }

        public IEnumerable<Conta> GetAll()
        {
            return ContaList;
        }

        public IEnumerable<Conta> GetByTipo(string tipo)
        {
            return ContaList;
        }

        public Conta Get(int id)
        {
            return ContaList.Find(s => s.IdConta == id);
        }

        public bool Add(Conta item)
        {
            int indice = 0;

            if (item == null)
            {
                return false;
            }

            indice = ContaList.FindIndex(s => s.IdConta == item.IdConta);
            if (indice == -1)
            {
                ContaList.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Remove(int id)
        {
            ContaList.RemoveAll(s => s.IdConta == id);
        }
        public bool Update(Conta item)
        {
            int indice = 0;

            if (item == null)
            {
                throw new ArgumentNullException("Conta");
            }

            indice = ContaList.FindIndex(s => s.IdConta == item.IdConta);
            if (indice == -1)
            {
                return false;
            }

            ContaList.RemoveAt(indice);
            ContaList.Add(item);
            return true;
        }

    }
}
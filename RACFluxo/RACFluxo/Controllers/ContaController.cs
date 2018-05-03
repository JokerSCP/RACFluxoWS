using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RACFluxo.Models;

namespace RACFluxo.Controllers
{
    public class ContaController : ApiController
    {
        static readonly IContaRepositorio ContaRepositorio = new ContaRepositorio();

        [HttpGetAttribute]
        public HttpResponseMessage GetAll()
        {
            List<Conta> contaList = ContaRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Conta>>(HttpStatusCode.OK, contaList);
        }

        [HttpGetAttribute]
        public HttpResponseMessage Get(int id)
        {
            Conta conta = ContaRepositorio.Get(id);

            if (conta == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Conta não localizaca para o Id informado!");
            }
            else
            {
                return Request.CreateResponse<Conta>(HttpStatusCode.OK, conta);
            }
        }

        [HttpGetAttribute]
        public IEnumerable<Conta> GetByTipo(string tipo)
        {
            return ContaRepositorio.GetAll().Where(e => string.Equals(e.Tipo, tipo, StringComparison.OrdinalIgnoreCase));
        }

        [HttpPostAttribute]
        public HttpResponseMessage Post(Conta item)
        {
            bool resultado = ContaRepositorio.Add(item);

            if (resultado)
            {
                var response = Request.CreateResponse<Conta>(HttpStatusCode.Created, item);
                string uri = Url.Link("DefaultApi", new { id = item.IdConta });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Conta não foi incluída!");
            }
        }

        [HttpPutAttribute]
        public HttpResponseMessage Put(int id, Conta item)
        {
            item.IdConta = id;

            if (!ContaRepositorio.Update(item))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não foi possível atualizar a conta para o id informado!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpDeleteAttribute]
        public HttpResponseMessage Delete(int id)
        {
            ContaRepositorio.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}

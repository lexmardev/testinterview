using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSysBank.BL;
using TestSysBank.EN;

namespace TestSysBank.API.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // GET: api/Clientes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ClienteBL.GetAll());
        }

        // GET: api/Clientes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return Ok(ClienteBL.GetById(id));
        }

        // POST: api/Clientes
        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            if (cliente != null)
            {
                int resultado = ClienteBL.Insert(cliente);
                if (resultado == 1)
                {
                    return Ok(1);
                }
            }
            return BadRequest();
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, Cliente cliente)
        {
            if (id != null && cliente != null)
            {
                cliente.IdCliente = Convert.ToInt64(id);
                int resultado = ClienteBL.Update(cliente);
                if (resultado == 1)
                {
                    return Ok(1);
                }
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                int resultado = ClienteBL.Delete(Convert.ToInt64(id));
                if (resultado == 1)
                {
                    return Ok("Exito");
                }
            }
            return BadRequest();
        }
    }
}

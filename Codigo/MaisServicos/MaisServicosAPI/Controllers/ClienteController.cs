using AutoMapper;
using Core;
using Core.Service;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaisServicosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController (IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }


        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaCliente = _clienteService.GetAll();
            if (listaCliente == null)
                return NotFound();

            return Ok(listaCliente);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Pessoa client = _clienteService.Get(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] ClienteViewModel clienteView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados invalidos.");

            var client = _mapper.Map<Pessoa>(clienteView);
            _clienteService.Create(client);

            return Ok();
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClienteViewModel clienteView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados Invalidos.");

            var client = _mapper.Map<Pessoa>(clienteView);
            if (client == null)
                return NotFound();

            _clienteService.Edit(client);

            return Ok();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Pessoa client = _clienteService.Get(id);
            if (client == null)
                return NotFound();

            _clienteService.Delete(id);
            return Ok();
        }
    }
}

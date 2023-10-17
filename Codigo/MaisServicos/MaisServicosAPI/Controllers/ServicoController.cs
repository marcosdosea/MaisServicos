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
    public class AutoresController : ControllerBase
    {
        private readonly IServicoService _servicoService;
        private readonly IMapper _mapper;

        public AutoresController(IServicoService servicoService, IMapper mapper)
        {
            _servicoService = servicoService;
            _mapper = mapper;
        }



        // GET: api/<ServicosController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaServicos = _servicoService.GetAll();
            if (listaServicos == null)
                return NotFound();
            return Ok(listaServicos);
        }

        // GET api/<ServicosController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Servico servico = _servicoService.Get(id);
            if (servico == null)
                return NotFound();
            return Ok(servico);
        }

        // POST api/<ServicosController>
        [HttpPost]
        public ActionResult Post([FromBody] ServicoViewModel servicoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var servico = _mapper.Map<Servico>(servicoModel);
            _servicoService.Create(servico);

            return Ok();
        }

        // PUT api/<ServicosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ServicoViewModel servicoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var servico = _mapper.Map<Servico>(servicoModel);
            if (servico == null)
                return NotFound();

            _servicoService.Edit(servico);

            return Ok();
        }

        // DELETE api/<ServicosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Servico servico = _servicoService.Get(id);
            if (servico == null)
                return NotFound();

            _servicoService.Delete(id);
            return Ok();
        }
    }
}


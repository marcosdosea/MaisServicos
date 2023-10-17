using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using Core.OrcamentoService;
using MaisServicosWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaisServicosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private readonly IOrcamentoService _orcamentoService;
        private readonly IMapper _mapper;

        public OrcamentoController(IOrcamentoService orcamentoService, IMapper mapper)
        {
            _orcamentoService = orcamentoService;
            _mapper = mapper;
        }



        // GET: api/<PrestadorController>
        [HttpGet]
        public ActionResult Get()
        {
            var listOrcamento = _orcamentoService.GetAll();
            if (listOrcamento == null)
            {
                return NotFound();
            }

            return Ok(listOrcamento);
        }

        // GET api/<PrestadorController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Orcamento orcamento = _orcamentoService.Get(id);
            if (orcamento == null)
            {
                return NotFound();
            }
            return Ok(orcamento);
        }

        // POST api/<PrestadorController>
        [HttpPost]
        public ActionResult Post([FromBody] OrcamentoViewModel orcamentoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados invalidos");
            }

            var orcamento = _mapper.Map<Orcamento>(orcamentoViewModel);
            _orcamentoService.Create(orcamento);

            return Ok();
        }

        // PUT api/<PrestadorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] OrcamentoViewModel orcamentoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados invalidos");
            }

            var orcamento = _mapper.Map<Orcamento>(orcamentoViewModel);
            if (orcamento == null)
            {
                return NotFound();
            }
            _orcamentoService.Create(orcamento);

            return Ok();
        }

        // DELETE api/<PrestadorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Orcamento orcamento = _orcamentoService.Get(id);
            if (orcamento == null)
            {
                NotFound();
            }

            _orcamentoService.Delete(id);
            return Ok();
        }
    }
}
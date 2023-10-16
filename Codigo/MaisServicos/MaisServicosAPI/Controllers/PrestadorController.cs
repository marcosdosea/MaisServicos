using AutoMapper;
using Core;
using Core.Service;
using MaisServicosAPI.Models;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaisServicosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : ControllerBase
    {

        private readonly IPrestadorService _prestadorService;
        private readonly IMapper _mapper;

        public PrestadorController(IPrestadorService prestadorService, IMapper mapper)
        {
            _prestadorService = prestadorService;
            _mapper = mapper;
        }



        // GET: api/<PrestadorController>
        [HttpGet]
        public ActionResult Get()
        {
            var listPrestador = _prestadorService.GetAll();
            if (listPrestador == null)
            {
                return NotFound();
            }

            return Ok(listPrestador);
        }

        // GET api/<PrestadorController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Pessoa prestador = _prestadorService.Get(id);
            if(prestador == null)
            {
                return NotFound();
            }
            return Ok(prestador);
        }

        // POST api/<PrestadorController>
        [HttpPost]
        public ActionResult Post([FromBody] PrestadorViewModel prestadorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados invalidos");
            }

            var prestador = _mapper.Map<Pessoa>(prestadorViewModel);
            _prestadorService.Create(prestador);

            return Ok(prestador);
        }

        // PUT api/<PrestadorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PrestadorViewModel prestadorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados invalidos");
            }

            var prestador = _mapper.Map<Pessoa>(prestadorViewModel);
            if (prestador == null)
            {
                return NotFound();
            }
            _prestadorService.Create(prestador);

            return Ok(prestador);
        }

        // DELETE api/<PrestadorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Pessoa prestador = _prestadorService.Get(id);
            if (prestador == null)
            {
                NotFound();
            }

            _prestadorService.Delete(id);
            return Ok();
        }
    }
}

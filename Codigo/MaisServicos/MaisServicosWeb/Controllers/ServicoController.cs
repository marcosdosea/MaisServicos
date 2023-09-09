using AutoMapper;
using Core;
using Core.Service;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ServiceProcess;

namespace MaisServicosWeb.Controllers
{
    public class ServicoController : Controller
    {
        private readonly IServicoService _servicoService;
        private readonly IMapper _mapper;

        public ServicoController(IServicoService servicoService, IMapper mapper)
        {
            _servicoService = servicoService;
            _mapper = mapper;
        }

        // GET: ServicoController
        public ActionResult Index()
        {
            var listaServicos = _servicoService.ConsultarTodos();
            var listaServicosModels = _mapper.Map<List<ServicoViewModel>>(listaServicos);
            return View(listaServicosModels);
        }

        // GET: ServicoController/Details/5
        public ActionResult Details(int id)
        {
            Servico servico = _servicoService.Obter(id);
            ServicoViewModel servicoModel = _mapper.Map<ServicoViewModel>(servico);
            return View(servicoModel);
        }

        // GET: ServicoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicoViewModel servicoModel)
        {
            if (ModelState.IsValid)
            {
                var servico = _mapper.Map<Servico>(servicoModel);
                _servicoService.Inserir(servico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServicoController/Edit/5
        public ActionResult Edit(int id)
        {
            Servico servico = _servicoService.Obter(id);
            ServicoViewModel servicoModel = _mapper.Map<ServicoViewModel>(servico);
            return View(servicoModel);
        }

        // POST: ServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServicoViewModel servicoModel)
        {
            if (ModelState.IsValid)
            {
                var servico = _mapper.Map<Servico>(servicoModel);
                _servicoService.Alterar(servico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServicoController/Delete/5
        public ActionResult Delete(int id)
        {
            Servico servico = _servicoService.Obter(id);
            ServicoViewModel servicoModel = _mapper.Map<ServicoViewModel>(servico);
            return View(servicoModel);
        }

        // POST: ServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ServicoViewModel servicoModel)
        {
            _servicoService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

using AutoMapper;
using Core;
using Core.OrcamentoService;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisServicosWeb.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly IOrcamentoService _orcamentoService;
        private readonly IMapper _mapper;

        public OrcamentoController(IOrcamentoService orcamentoService, IMapper mapper)
        {
            _orcamentoService = orcamentoService;
            _mapper = mapper;
        }

        // GET: OrcamentoController
        public ActionResult Index()
        {
            var listaOrcamentos = _orcamentoService.ConsultarTodos();
            var listaOrcamentosModels = _mapper.Map<List<OrcamentoModel>>(listaOrcamentos);
            return View(listaOrcamentosModels);
        }

        // GET: OrcamentoController/Details/5
        public ActionResult Details(int id)
        {
            Orcamento orcamento = _orcamentoService.BuscarOrcamento(id);
            OrcamentoModel orcamentoModel = _mapper.Map<OrcamentoModel>(orcamento);
            return View(orcamentoModel);
        }

        // GET: OrcamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrcamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrcamentoModel orcamentoModel)
        {
            if (ModelState.IsValid)
            {
                var orcamento = _mapper.Map<Orcamento>(orcamentoModel);
                _orcamentoService.InserirOrcamento(orcamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrcamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            Orcamento orcamento = _orcamentoService.BuscarOrcamento(id);
            OrcamentoModel orcamentoModel = _mapper.Map<OrcamentoModel>(orcamento);
            return View(orcamentoModel);
        }

        // POST: OrcamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrcamentoModel orcamentoModel)
        {
            if (ModelState.IsValid)
            {
                var orcamento = _mapper.Map<Orcamento>(orcamentoModel);
                _orcamentoService.AlterarOrcamento(orcamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrcamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            Orcamento orcamento = _orcamentoService.BuscarOrcamento(id);
            OrcamentoModel orcamentoModel = _mapper.Map<OrcamentoModel>(orcamento);
            return View(orcamentoModel);
        }

        // POST: OrcamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrcamentoModel orcamentoModel)
        {
            _orcamentoService.ExcluirOrcamento(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

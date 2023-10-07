using AutoMapper;
using Core;
using Core.OrcamentoService;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaisServicosWeb.Controllers
{
    [Authorize(Roles = "prestador")]
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
            var listaOrcamentos = _orcamentoService.GetAll();
            var listaOrcamentosModels = _mapper.Map<List<OrcamentoViewModel>>(listaOrcamentos);
            return View(listaOrcamentosModels);
        }

        // GET: OrcamentoController/Details/5
        public ActionResult Details(int id)
        {
            Orcamento orcamento = _orcamentoService.Get(id);
            OrcamentoViewModel orcamentoModel = _mapper.Map<OrcamentoViewModel>(orcamento);
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
        public ActionResult Create(OrcamentoViewModel orcamentoModel)
        {
            if (ModelState.IsValid)
            {
                var orcamento = _mapper.Map<Orcamento>(orcamentoModel);
                _orcamentoService.Create(orcamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrcamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            Orcamento orcamento = _orcamentoService.Get(id);
            OrcamentoViewModel orcamentoModel = _mapper.Map<OrcamentoViewModel>(orcamento);
            return View(orcamentoModel);
        }

        // POST: OrcamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrcamentoViewModel orcamentoModel)
        {
            if (ModelState.IsValid)
            {
                var orcamento = _mapper.Map<Orcamento>(orcamentoModel);
                _orcamentoService.Edit(orcamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrcamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            Orcamento orcamento = _orcamentoService.Get(id);
            OrcamentoViewModel orcamentoModel = _mapper.Map<OrcamentoViewModel>(orcamento);
            return View(orcamentoModel);
        }

        // POST: OrcamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrcamentoViewModel orcamentoModel)
        {
            _orcamentoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

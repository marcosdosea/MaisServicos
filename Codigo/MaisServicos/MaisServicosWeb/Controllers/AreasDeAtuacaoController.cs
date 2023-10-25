using AutoMapper;
using Core;
using Core.Service;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisServicosWeb.Controllers
{
    public class AreasDeAtuacaoController : Controller
    {
        private readonly IAreaDeAtuacaoService _areaDeAtuacaoService;
        private readonly IMapper _mapper;

        public AreasDeAtuacaoController (IAreaDeAtuacaoService areaDeAtuacaoService, IMapper mapper)
        {
            _areaDeAtuacaoService = areaDeAtuacaoService;
            _mapper = mapper;
        }

        // GET: AreasDeAtuacaoController
        public ActionResult Index()
        {
            var listaAreas = _areaDeAtuacaoService.GetAll();
            var listaAreaView = _mapper.Map<List<AreaDeAtuacaoViewModel>>(listaAreas);
            return View(listaAreaView);
        }

        // GET: AreasDeAtuacaoController/Details/5
        public ActionResult Details(int id)
        {
            Areadeatuacao area = _areaDeAtuacaoService.Get(id);
            AreaDeAtuacaoViewModel areaView = _mapper.Map<AreaDeAtuacaoViewModel>(area);
            return View(areaView);
        }

        // GET: AreasDeAtuacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreasDeAtuacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AreaDeAtuacaoViewModel areaViewModel)
        {
            if (ModelState.IsValid)
            {
                var area = _mapper.Map<Areadeatuacao>(areaViewModel);
                _areaDeAtuacaoService.Create(area);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AreasDeAtuacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            Areadeatuacao area = _areaDeAtuacaoService.Get(id);
            AreaDeAtuacaoViewModel areaViewModel = _mapper.Map<AreaDeAtuacaoViewModel>(area);
            return View(areaViewModel);
        }

        // POST: AreasDeAtuacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AreaDeAtuacaoViewModel areaDeAtuacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var area = _mapper.Map<Areadeatuacao>(areaDeAtuacaoViewModel);
                _areaDeAtuacaoService.Edit(area);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AreasDeAtuacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            Areadeatuacao area = _areaDeAtuacaoService.Get(id);
            AreaDeAtuacaoViewModel areaDeAtuacaoViewModel = _mapper.Map<AreaDeAtuacaoViewModel>(area);
            return View(areaDeAtuacaoViewModel);
        }

        // POST: AreasDeAtuacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AreaDeAtuacaoViewModel areaDeAtuacaoViewModel)
        {
            _areaDeAtuacaoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

using AutoMapper;
using Core;
using Core.Service;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisServicosWeb.Controllers
{
    public class PrestadorController : Controller
    {
        private readonly IPrestadorService _prestadorService;
        private readonly IMapper _mapper;

        public PrestadorController (IPrestadorService prestadorService, IMapper mapper)
        {
            _prestadorService = prestadorService;
            _mapper = mapper;
        }

        // GET: PrestadorController
        public ActionResult Index()
        {
            var listaPrestadores = _prestadorService.GetAll();
            var listaPrestadorModel = _mapper.Map<List<PrestadorViewModel>>(listaPrestadores);
            return View(listaPrestadorModel);
        }

        // GET: PrestadorController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa prestador = _prestadorService.Get(id);
            PrestadorViewModel prestadorViewModel = _mapper.Map<PrestadorViewModel>(prestador);
            return View(prestadorViewModel);
        }

        // GET: PrestadorController/Create
        public ActionResult Create()
        {
           return View();
        }

        // POST: PrestadorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrestadorViewModel prestadorViewModel)
        {
            if (ModelState.IsValid)
            {
                var prestador = _mapper.Map<Pessoa>(prestadorViewModel);
                _prestadorService.Create(prestador);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PrestadorController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa prestador = _prestadorService.Get(id);
            PrestadorViewModel prestadorViewModel = _mapper.Map<PrestadorViewModel>(prestador);
            return View(prestadorViewModel);
        }

        // POST: PrestadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PrestadorViewModel prestadorViewModel)
        {
            if (ModelState.IsValid)
            {
                var prestador = _mapper.Map<Pessoa>(prestadorViewModel);
                _prestadorService.Edit(prestador);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PrestadorController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa prestador = _prestadorService.Get(id);
            PrestadorViewModel prestadorViewModel = _mapper.Map<PrestadorViewModel>(prestador);
            return View(prestadorViewModel);
        }

        // POST: PrestadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PrestadorViewModel prestadorViewModel)
        {
            _prestadorService.Delete(id);
            return RedirectToAction(nameof(Index)); 
        }
    }
}

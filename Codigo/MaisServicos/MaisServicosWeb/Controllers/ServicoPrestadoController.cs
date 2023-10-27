using AutoMapper;
using Core;
using Core.Service;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MaisServicosWeb.Controllers
{
    public class ServicoPrestadoController : Controller
    {
        private readonly IServicoPrestadoService _servicoPrestadoService;
        private readonly IMapper _mapper;

        public ServicoPrestadoController(IServicoPrestadoService servicoPrestadoService, IMapper mapper)
        {
            _servicoPrestadoService = servicoPrestadoService;
            _mapper = mapper;
        }
        // GET: ServicoPrestadoController
        public ActionResult Index()
        {
            var listaServicosPrestados = _servicoPrestadoService.GetAll();
            var listaServicosPrestadoView = _mapper.Map<List<ServicoPrestadoViewModel>>(listaServicosPrestados);
            return View(listaServicosPrestadoView);
        }

        // GET: ServicoPrestadoController/Details/5
        public ActionResult Details(int id)
        {
            Servico servicoPrestado = _servicoPrestadoService.Get(id);
            ServicoPrestadoViewModel servicoPrestadoView = _mapper.Map<ServicoPrestadoViewModel>(servicoPrestado);
            return View(servicoPrestadoView);
        }

        // GET: ServicoPrestadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicoPrestadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IServicoPrestadoService servicoPrestadoView)
        {
            if (ModelState.IsValid)
            {
                var servicoPrestado = _mapper.Map<Servico>(servicoPrestadoView);
                _servicoPrestadoService.Create(servicoPrestado);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServicoPrestadoController/Edit/5
        public ActionResult Edit(int id)
        {
            Servico servicoPrestado = _servicoPrestadoService.Get(id);
            ServicoPrestadoViewModel servicoPrestadoView = _mapper.Map<ServicoPrestadoViewModel>(servicoPrestado);
            return View(servicoPrestadoView);
        }

        // POST: ServicoPrestadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServicoPrestadoViewModel servicoPrestadoView)
        {
            if (ModelState.IsValid)
            {
                var servicoPrestado = _mapper.Map<Servico>(servicoPrestadoView);
                _servicoPrestadoService.Edit(servicoPrestado);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServicoPrestadoController/Delete/5
        public ActionResult Delete(int id)
        {
            Servico servicoPrestado = _servicoPrestadoService.Get(id);
            ServicoPrestadoViewModel servicoPrestadoView = _mapper.Map<ServicoPrestadoViewModel>(servicoPrestado);
            return View(servicoPrestadoView);
        }

        // POST: ServicoPrestadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ServicoPrestadoViewModel servicoPrestadoView)
        {
            _servicoPrestadoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

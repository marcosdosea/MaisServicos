using AutoMapper;
using Core;
using Core.Service;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisServicosWeb.Controllers
{
    public class AvaliarClienteController : Controller
    {

        private readonly IAvaliarClienteService _avaliarClienteService;
        private readonly IMapper _mapper;


        public AvaliarClienteController(IAvaliarClienteService avaliarClienteService, IMapper mapper)
        {
            _avaliarClienteService = avaliarClienteService;
            _mapper = mapper;
        }


        // GET: AvaliarClienteController
        public ActionResult Index()
        {
            var listAvaliarClientes = _avaliarClienteService.GetAll();
            var listAvaliarClienteModel = _mapper.Map<List<AvaliarClienteViewModel>>(listAvaliarClientes);
            return View(listAvaliarClienteModel);
        }

        // GET: AvaliarClienteController/Details/5
        public ActionResult Details(int id)
        {   
            Avaliacao client =_avaliarClienteService.Get(id);
            AvaliarClienteViewModel avaliarClienteViewModel = _mapper.Map<AvaliarClienteViewModel>(client);
            return View(avaliarClienteViewModel);
        }

        // GET: AvaliarClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvaliarClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvaliarClienteViewModel avaliarClienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<Avaliacao>(avaliarClienteViewModel);
                _avaliarClienteService.Create(client);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AvaliarClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            Avaliacao client = _avaliarClienteService.Get(id);
            AvaliarClienteViewModel avaliarClienteViewModel = _mapper.Map<AvaliarClienteViewModel>(client);
            return View(avaliarClienteViewModel);
        }

        // POST: AvaliarClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AvaliarClienteViewModel avaliarClienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<Avaliacao>(avaliarClienteViewModel);
                _avaliarClienteService.Edit(client);
            }
            return RedirectToAction(nameof(Index));   
        }

        // GET: AvaliarClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            Avaliacao cliente = _avaliarClienteService.Get(id);
            AvaliarClienteViewModel avaliarClienteViewModel = _mapper.Map<AvaliarClienteViewModel>(cliente);
            return View(avaliarClienteViewModel);
        }

        // POST: AvaliarClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AvaliarClienteViewModel avaliarClienteViewModel)
        {
           _avaliarClienteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

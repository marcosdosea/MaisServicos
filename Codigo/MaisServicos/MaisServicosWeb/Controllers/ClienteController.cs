using AutoMapper;
using Core;
using Core.Service;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisServicosWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            var listaClientes = _clienteService.GetAll();
            var listaClienteModel = _mapper.Map<List<ClienteViewModel>>(listaClientes);
            return View(listaClienteModel);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa client = _clienteService.Get(id);
            ClienteViewModel clienteViewModel = _mapper.Map<ClienteViewModel>(client);
            return View(clienteViewModel);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<Pessoa>(clienteViewModel);
                _clienteService.Create(client);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa client = _clienteService.Get(id);
            ClienteViewModel clienteViewModel = _mapper.Map<ClienteViewModel>(client);
            return View(clienteViewModel);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<Pessoa>(clienteViewModel);
                _clienteService.Edit(client);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa client = _clienteService.Get(id);
            ClienteViewModel clienteViewModel = _mapper.Map<ClienteViewModel>(client);
            return View(clienteViewModel);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ClienteViewModel clienteViewModel)
        {
            _clienteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

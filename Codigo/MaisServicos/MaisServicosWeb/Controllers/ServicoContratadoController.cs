using AutoMapper;
using Core;
using Core.Service;
using MaisServicosWeb.Mappers;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.ServiceProcess;

namespace MaisServicosWeb.Controllers
{
    public class ServicoContratadoController : Controller
    {
        private readonly IServicoContratado? _servicoContratado;
        private readonly IMapper? _mapper;

        // GET: ServicoController
        public ActionResult Index()
        {
            var listaServicos = _servicoContratado.GetAll();
            var listaServicosModels = _mapper.Map<List<ServicoContratadoViewModel>>(listaServicos);
            return View(listaServicosModels);
        }

        // GET: ServicoController/Details/5
        public ActionResult Details(int id)
        {
            Servicocontratado servico = _servicoContratado.Get(id);
            ServicoContratadoViewModel servicoModel = _mapper.Map<ServicoContratadoViewModel>(servico);
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
        public ActionResult Create(ServicoContratadoViewModel servicoModel)
        {
            if (ModelState.IsValid)
            {
                var servico = _mapper.Map<Servicocontratado>(servicoModel);
                _servicoContratado.Create(servico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServicoController/Edit/5
        public ActionResult Edit(int id)
        {
            Servicocontratado servico = _servicoContratado.Get(id);
            ServicoContratadoViewModel servicoModel = _mapper.Map<ServicoContratadoViewModel>(servico);
            return View(servicoModel);
        }

        // POST: ServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServicoContratadoViewModel servicoModel)
        {
            if (ModelState.IsValid)
            {
                var servico = _mapper.Map<Servicocontratado>(servicoModel);
                _servicoContratado.Edit(servico);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServicoController/Delete/5
        public ActionResult Delete(int id)
        {
            Servicocontratado servico = _servicoContratado.Get(id);
            ServicoContratadoViewModel servicoModel = _mapper.Map<ServicoContratadoViewModel>(servico);
            return View(servicoModel);
        }

        // POST: ServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ServicoContratadoViewModel servicoModel)
        {
            _servicoContratado.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

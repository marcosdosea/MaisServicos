using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.OrcamentoService;

namespace Service.Tests
{
    [TestClass()]
    public class OrcamentoServiceTests
    {
        private MaisServicosContext _context;
        private IOrcamentoService _orcamentoService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrenge
            var builder = new DbContextOptionsBuilder<MaisServicosContext>();
            builder.UseInMemoryDatabase("MaisServicos");
            var options = builder.Options;

            _context = new MaisServicosContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var orcamentos = new List<Orcamento>
            {
                new Orcamento
                {
                Id = 1,
                Valor = 10000,
                Descricao = "Durante a inspeção, foi identificado que a tomada estava defeituosa, sendo necessária a subetituição da mesma",
                IdSolicita = 1
                },
                new Orcamento
                {
                Id = 2,
                Valor = 200,
                Descricao = "Instalação de lâmpada no banheiro",
                IdSolicita = 2
                },
                new Orcamento
                {
                Id = 3,
                Valor = 5500,
                Descricao = "Reforma do piso do quarto",
                IdSolicita = 3
                }
            };
            _context.AddRange(orcamentos);
            _context.SaveChanges();

            _orcamentoService = new OrcamentoService(_context);
        }
        [TestMethod()]
        public void CreateTest()
        {
            //Act
            _orcamentoService.Create(new Orcamento
            {
                Id = 4,
                Valor = 800,
                Descricao = "Rebocar parede",
                IdSolicita = 4
            });

            //Assert
            Assert.AreEqual(4, _orcamentoService.GetAll().Count());
            var orcamento = _orcamentoService.Get(4);
            Assert.AreEqual("4", orcamento.Id);
            Assert.AreEqual("800", orcamento.Valor);
            Assert.AreEqual("Rebocar parede", orcamento.Descricao);
            Assert.AreEqual("4", orcamento.IdSolicita);
        }
        [TestMethod()]
        public void DeleteTest()
        {
            //Act
            _orcamentoService.Delete(2);
            //Assert
            Assert.AreEqual(2, _orcamentoService.GetAll().Count());
            var orcamento = _orcamentoService.Get(2);
            Assert.AreEqual(null, orcamento);
        }
        [TestMethod()]
        public void EditTest()
        {
            //Act
            var orcamento = _orcamentoService.Get(3);
            orcamento.Valor = 5500;
            orcamento.Descricao = "Reforma do piso do quarto";
            _orcamentoService.Edit(orcamento);

            //Assert
            orcamento = _orcamentoService.Get(3);
            Assert.IsNotNull(orcamento);
            Assert.AreEqual(5500, orcamento.Valor);
            Assert.AreEqual("Reforma do piso do quarto", orcamento.Descricao);
        }
        [TestMethod()]
        public void GetTest()
        {
            var orcamento = _orcamentoService.Get(1);
            Assert.IsNotNull(orcamento);
            Assert.AreEqual(5500, orcamento.Valor);
            Assert.AreEqual("Reforma do piso do quarto", orcamento.Descricao);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Act
            var orcamentoClient = _orcamentoService.GetAll();
            //Assert
            Assert.IsInstanceOfType(orcamentoClient, typeof(IEnumerable<Orcamento>));
            Assert.IsNotNull(orcamentoClient);
            Assert.AreEqual(3, orcamentoClient.Count());
            Assert.AreEqual(1, orcamentoClient.First().Id);
            Assert.AreEqual(5500, orcamentoClient.First().Valor);
        }
    }
}
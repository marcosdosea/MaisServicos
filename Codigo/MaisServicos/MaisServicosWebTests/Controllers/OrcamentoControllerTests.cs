using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Service;
using Moq;
using AutoMapper;
using MaisServicosWeb.Mappers;
using Core;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Core.OrcamentoService;

namespace MaisServicosWeb.Controllers.Tests
{
    [TestClass()]
    public class OrcamentoControllerTests
    {
        private static OrcamentoController controller;
        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<IOrcamentoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new OrcamentoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestOrcamentos());
            mockService.Setup(service => service.Get(1)).Returns(GetTargetOrcamento());
            mockService.Setup(service => service.Edit(It.IsAny<Orcamento>())).Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Orcamento>())).Verifiable();

            controller = new OrcamentoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<OrcamentoViewModel>));

            List<OrcamentoViewModel>? lista = (List<OrcamentoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            //Act
            var result = controller.Details(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrcamentoViewModel));
            OrcamentoViewModel orcamentoView = (OrcamentoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(10000, orcamentoView.Valor);
            Assert.AreEqual("Durante a inspeção, foi identificado que a tomada estava defeituosa, sendo necessária a substituição da mesma", orcamentoView.Descricao);
        }
        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            //Act
            var result = controller.Create(GetNewOrcamento());

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        [TestMethod()]
        public void CreateTest_Invalid()
        {
            //Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            //Act
            var result = controller.Create(GetNewOrcamento());

            //Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        [TestMethod()]
        public void EditTest_Get()
        {
            //Act
            var result = controller.Edit(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrcamentoViewModel));
            OrcamentoViewModel orcamentoView = (OrcamentoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(10000, orcamentoView.Valor);
            Assert.AreEqual("Durante a inspeção, foi identificado que a tomada estava defeituosa, sendo necessária a substituição da mesma", orcamentoView.Descricao);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            //Act
            var result = controller.Edit(GetTargetOrcamento().Id, GetTargetOrcamentoViewModel());

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }



        [TestMethod()]
        public void DeleteTest_Post()
        {
            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrcamentoViewModel));
            OrcamentoViewModel orcamentoView = (OrcamentoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(10000, orcamentoView.Valor);
            Assert.AreEqual("Durante a inspeção, foi identificado que a tomada estava defeituosa, sendo necessária a substituição da mesma", orcamentoView.Descricao);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetOrcamento().Id, GetTargetOrcamentoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private OrcamentoViewModel GetNewOrcamento()
        {
            return new OrcamentoViewModel
            {
                Id = 4,
                Valor = 10000,
                Descricao = "Troca de resistencia do chuveiro elétrico",
                IdSolicita = 4
            };
        }

        private Orcamento GetTargetOrcamento()
        {
            return new Orcamento
            {
                Id = 1,
                Valor = 10000,
                Descricao = "Durante a inspeção, foi identificado que a tomada estava defeituosa, sendo necessária a substituição da mesma",
                IdSolicita = 1
            };
        }
        private OrcamentoViewModel GetTargetOrcamentoViewModel()
        {
            return new OrcamentoViewModel
            {
                Id = 2,
                Valor = 10000,
                Descricao = "Durante a inspeção, foi identificado que a tomada estava defeituosa, sendo necessária a substituição da mesma",
                IdSolicita = 2
            };
        }

        private IEnumerable<Orcamento> GetTestOrcamentos()
        {
            return new List<Orcamento>
            {
                new Orcamento {
                Id = 1,
                Valor = 10000,
                Descricao = "Durante a inspeção, foi identificado que a tomada estava defeituosa, sendo necessária a substituição da mesma",
                IdSolicita = 1
                },
                new Orcamento {
                Id = 2,
                Valor = 200,
                Descricao = "Instalação de lâmpada no banheiro",
                IdSolicita = 2
                },
                new Orcamento {
                Id = 3,
                Valor = 5500,
                Descricao = "Reforma do piso do quarto",
                IdSolicita = 3
                },
            };
        }
    }
}
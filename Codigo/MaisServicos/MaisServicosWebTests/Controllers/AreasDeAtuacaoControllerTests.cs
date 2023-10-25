using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaisServicosWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Core.Service;
using AutoMapper;
using MaisServicosWeb.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using MaisServicosWeb.Models;

namespace MaisServicosWeb.Controllers.Tests
{
    [TestClass()]
    public class AreasDeAtuacaoControllerTests
    {
        private static AreasDeAtuacaoController controller;

        [TestInitialize]
        public void Inicialize()
        {
            var mockService = new Mock<IAreaDeAtuacaoService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AreaDeAtuacaoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestAreasDeAtuacao());
            mockService.Setup(service => service.Get(1)).Returns(GetTargetAreasDeAtuacao());
            mockService.Setup(service => service.Edit(It.IsAny<Areadeatuacao>())).Verifiable();
            controller = new AreasDeAtuacaoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AreaDeAtuacaoViewModel>));

            List<AreaDeAtuacaoViewModel>? lista = (List<AreaDeAtuacaoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AreaDeAtuacaoViewModel));
            AreaDeAtuacaoViewModel areaDeAtuacaoView = (AreaDeAtuacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Pedreiro", areaDeAtuacaoView.Nome);
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
            var result = controller.Create(GetNewAreaDeAtuacao());

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
            var result = controller.Create(GetNewAreaDeAtuacao());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AreaDeAtuacaoViewModel));
            AreaDeAtuacaoViewModel areaDeAtuacaoView = (AreaDeAtuacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Pedreiro", areaDeAtuacaoView.Nome);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            //Act
            var result = controller.Edit(GetTargetAreasDeAtuacao().Id, GetTargetAreaDeAtuacaoViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AreaDeAtuacaoViewModel));
            AreaDeAtuacaoViewModel areaDeAtuacaoView = (AreaDeAtuacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Pedreiro", areaDeAtuacaoView.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetAreaDeAtuacaoViewModel().Id, GetTargetAreaDeAtuacaoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private AreaDeAtuacaoViewModel GetNewAreaDeAtuacao()
        {
            return new AreaDeAtuacaoViewModel
            {
                Id = 4,
                Nome = "Encanador"
            };
        }

        private Areadeatuacao GetTargetAreasDeAtuacao()
        {
            return new Areadeatuacao
            {
                Id = 1,
                Nome = "Pedreiro"
            };
        }

        private AreaDeAtuacaoViewModel GetTargetAreaDeAtuacaoViewModel()
        {
            return new AreaDeAtuacaoViewModel
            {
                Id = 1,
                Nome = "Pedreiro"
            };
        }

        private IEnumerable<Areadeatuacao> GetTestAreasDeAtuacao()
        {
            return new List<Areadeatuacao>
            {
                new Areadeatuacao
                {
                    Id = 1,
                    Nome = "Pedreiro"
                },
                new Areadeatuacao
                {
                    Id = 2,
                    Nome = "Eletricista"
                },
                new Areadeatuacao
                {
                    Id = 3,
                    Nome = "Gesseiro"
                }
            };
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Service;
using Moq;
using AutoMapper;
using MaisServicosWeb.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using MaisServicosWeb.Models;

namespace MaisServicosWeb.Controllers.Tests
{
    [TestClass()]
    public class ServicoControllerTests
    {

        private static ServicoController controller;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<IServicoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ServicoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestServicos());
            mockService.Setup(service => service.Get(1)).Returns(GetTargetServico());
            mockService.Setup(service => service.Edit(It.IsAny<Servico>())).Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Servico>())).Verifiable();

            controller = new ServicoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ServicoViewModel>));

            List<ServicoViewModel>? lista = (List<ServicoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest_Valido()
        {
            //Act
            var result = controller.Details(1);

            //Arrange
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ServicoViewModel));
            ServicoViewModel servicoModel = (ServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Casa Nova Remodelada", servicoModel.Nome);
            Assert.AreEqual("Renovação completa ou parcial de residências para modernizar e melhorar o espaço.", servicoModel.Descricao);

        }

        [TestMethod()]
        public void CreateTest_Get_Valido()
        {
            //Act
            var result = controller.Create();

            //Arrange
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valido()
        {
            //Act
            var result = controller.Create(GetNewServico());

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_Post_Invalido()
        {
            //Arrange
            controller.ModelState.AddModelError("Nome", "Campo Requerido");

            //Act
            var result = controller.Create(GetNewServico());

            //Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Get_Valido()
        {
            //Act
            var result = controller.Edit(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ServicoViewModel));
            ServicoViewModel servicoModel = (ServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Casa Nova Remodelada", servicoModel.Nome);
            Assert.AreEqual("Renovação completa ou parcial de residências para modernizar e melhorar o espaço.", servicoModel.Descricao);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            //Act
            var result = controller.Edit(GetTargetServicoModel().Id, GetTargetServicoModel());

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ServicoViewModel));
            ServicoViewModel servicoModel = (ServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Casa Nova Remodelada", servicoModel.Nome);
            Assert.AreEqual("Renovação completa ou parcial de residências para modernizar e melhorar o espaço.", servicoModel.Descricao);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            //Act
            var result = controller.Delete(GetTargetServicoModel().Id, GetTargetServicoModel());

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ServicoViewModel GetNewServico()
        {
            return new ServicoViewModel { Id = 4, Nome = "Jardins Vivos", Descricao = "Serviço de paisagismo e jardinagem para criar e manter jardins vibrantes e harmoniosos.", IdAreaDeAtuacao = 4 };
        }

        private static Servico GetTargetServico()
        {
            return new Servico
            {
                Id = 1,
                Nome = "Casa Nova Remodelada",
                Descricao = "Renovação completa ou parcial de residências para modernizar e melhorar o espaço.",
                IdAreaDeAtuacao = 1
            };
        }

        private static ServicoViewModel GetTargetServicoModel()
        {
            return new ServicoViewModel
            {
                Id = 2,
                Nome = "Casa Nova Remodelada",
                Descricao = "Renovação completa ou parcial de residências para modernizar e melhorar o espaço.",
                IdAreaDeAtuacao = 2
            };
        }

        private IEnumerable<Servico> GetTestServicos()
        {
            return new List<Servico>
            {
                new Servico
                {
                    Id = 1,
                    Nome = "Casa Nova Remodelada",
                    Descricao = "Renovação completa ou parcial de residências para modernizar e melhorar o espaço.",
                    IdAreaDeAtuacao = 1
                },
                new Servico
                {
                    Id = 2,
                    Nome = "Arte nas Paredes",
                    Descricao = "Transformação de ambientes através de pintura e acabamentos estéticos.",
                    IdAreaDeAtuacao = 2
                },
                new Servico
                {
                    Id = 3,
                    Nome = "AquaLux Piscinas",
                    Descricao = "Construção profissional de piscinas, desde a escavação até o acabamento final.",
                    IdAreaDeAtuacao = 3
                },
            };
        }
    }
}
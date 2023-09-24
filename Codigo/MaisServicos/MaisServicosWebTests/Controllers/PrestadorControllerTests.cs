using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaisServicosWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Service;
using Moq;
using MaisServicosWeb.Mappers;
using Core;
using MaisServicosWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaisServicosWeb.Controllers.Tests
{
    [TestClass()]
    public class PrestadorControllerTests
    {
        private static PrestadorController controller;


        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<IPrestadorService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PrestadorProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestPrestadores());
            mockService.Setup(service => service.Get(1)).Returns(GetTargetPrestador());
            mockService.Setup(service => service.Edit(It.IsAny<Pessoa>())).Verifiable();
            controller = new PrestadorController(mockService.Object, mapper);

        }


        [TestMethod()]
        public void PrestadorControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexTest()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PrestadorViewModel>));

            List<PrestadorViewModel>? lista = (List<PrestadorViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PrestadorViewModel));
            PrestadorViewModel prestadorView = (PrestadorViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Yuri Alberto", prestadorView.Nome);
            Assert.AreEqual("bagrealberto@gmail.com", prestadorView.Email);
            Assert.AreEqual("14735834556", prestadorView.Cpf);
            Assert.AreEqual("13999873456", prestadorView.Telefone);
            Assert.AreEqual("49000499", prestadorView.Cep);
            Assert.AreEqual("SE", prestadorView.Estado);
            Assert.AreEqual("Itabaiana", prestadorView.Cidade);
            Assert.AreEqual("Marianga", prestadorView.Bairro);
            Assert.AreEqual("Gaviões da fiel", prestadorView.Rua);
            Assert.AreEqual("09", prestadorView.NumeroCasa);
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
            var result = controller.Create(GetNewPrestador());

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
            var result = controller.Create(GetNewPrestador());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PrestadorViewModel));
            PrestadorViewModel prestadorView = (PrestadorViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Yuri Alberto", prestadorView.Nome);
            Assert.AreEqual("bagrealberto@gmail.com", prestadorView.Email);
            Assert.AreEqual("14735834556", prestadorView.Cpf);
            Assert.AreEqual("13999873456", prestadorView.Telefone);
            Assert.AreEqual("49000499", prestadorView.Cep);
            Assert.AreEqual("SE", prestadorView.Estado);
            Assert.AreEqual("Itabaiana", prestadorView.Cidade);
            Assert.AreEqual("Marianga", prestadorView.Bairro);
            Assert.AreEqual("Gaviões da fiel", prestadorView.Rua);
            Assert.AreEqual("09", prestadorView.NumeroCasa);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            //Act
            var result = controller.Edit(GetTargetPrestador().Id, GetTargetPrestadorViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PrestadorViewModel));
            PrestadorViewModel prestadorView = (PrestadorViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Yuri Alberto", prestadorView.Nome);
            Assert.AreEqual("bagrealberto@gmail.com", prestadorView.Email);
            Assert.AreEqual("14735834556", prestadorView.Cpf);
            Assert.AreEqual("13999873456", prestadorView.Telefone);
            Assert.AreEqual("49000499", prestadorView.Cep);
            Assert.AreEqual("SE", prestadorView.Estado);
            Assert.AreEqual("Itabaiana", prestadorView.Cidade);
            Assert.AreEqual("Marianga", prestadorView.Bairro);
            Assert.AreEqual("Gaviões da fiel", prestadorView.Rua);
            Assert.AreEqual("09", prestadorView.NumeroCasa);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetPrestadorViewModel().Id, GetTargetPrestadorViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PrestadorViewModel GetNewPrestador()
        {
            return new PrestadorViewModel
            {
                Id = 4,
                Nome = "Fabio Santos",
                Email = "tiochico@gmail.com",
                Cpf = "32748726487",
                Telefone = "87999871234",
                Cep = "53699455",
                Estado = "CE",
                Cidade = "Foertaleza",
                Bairro = "Invasão",
                Rua = "Fiel Macabra",
                NumeroCasa = "06"
            };
        }

        private Pessoa GetTargetPrestador()
        {
            return new Pessoa
            {
                Id = 1,
                Nome = "Yuri Alberto",
                Email = "bagrealberto@gmail.com",
                Cpf = "14735834556",
                Telefone = "13999873456",
                Cep = "49000499",
                Estado = "SE",
                Cidade = "Itabaiana",
                Bairro = "Marianga",
                Rua = "Gaviões da fiel",
                Numero = "09"
            };
        }

        private PrestadorViewModel GetTargetPrestadorViewModel()
        {
            return new PrestadorViewModel
            {
                Id = 2,
                Nome = "Yuri Alberto",
                Email = "bagrealberto@gmail.com",
                Cpf = "14735834556",
                Telefone = "13999873456",
                Cep = "49000499",
                Estado = "SE",
                Cidade = "Itabaiana",
                Bairro = "Marianga",
                Rua = "Gaviões da fiel",
                NumeroCasa = "09"
            };
        }

        private IEnumerable<Pessoa> GetTestPrestadores()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1,
                    Nome = "Yuri Alberto",
                    Email = "bagrealberto@gmail.com",
                    Cpf = "14735834556",
                    Telefone = "13999873456",
                    Cep = "49000499",
                    Estado = "SE",
                    Cidade = "Itabaiana",
                    Bairro = "Marianga",
                    Rua = "Gaviões da fiel",
                    Numero = "09"
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Renato Augusto",
                    Email = "reinatoA@gmail.com",
                    Cpf = "98587367423",
                    Telefone = "79999765438",
                    Cep = "49578300",
                    Estado = "PE",
                    Cidade = "São Domingos",
                    Bairro = "Ponto Novo",
                    Rua = "Camisa 12",
                    Numero = "08"
                },
                new Pessoa
                {
                    Id = 1,
                    Nome = "Cássio Ramos",
                    Email = "gigantecassio@gmail.com",
                    Cpf = "37498476136",
                    Telefone = "75998439895",
                    Cep = "49733744",
                    Estado = "SP",
                    Cidade = "São Paulo",
                    Bairro = "Itaquera",
                    Rua = "Pavilhão Nove",
                    Numero = "12"
                }
            };
        }

    }
}
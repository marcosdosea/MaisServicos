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
    public class ClienteControllerTests
    {
        private static ClienteController controller;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<IClienteService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new ClienteProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestClientes());
            mockService.Setup(service => service.Get(1)).Returns(GetTargetCliente());
            mockService.Setup(service => service.Edit(It.IsAny<Pessoa>())).Verifiable();
            controller = new ClienteController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ClienteViewModel>));

            List<ClienteViewModel>? lista = (List<ClienteViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ClienteViewModel));
            ClienteViewModel clienteView = (ClienteViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Yuri Alberto", clienteView.Nome);
            Assert.AreEqual("bagrealberto@gmail.com", clienteView.Email);
            Assert.AreEqual("14735834556", clienteView.Cpf);
            Assert.AreEqual("13999873456", clienteView.Telefone);
            Assert.AreEqual("49000499", clienteView.Cep);
            Assert.AreEqual("SE", clienteView.Estado);
            Assert.AreEqual("Itabaiana", clienteView.Cidade);
            Assert.AreEqual("Marianga", clienteView.Bairro);
            Assert.AreEqual("Gaviões da fiel", clienteView.Rua);
            Assert.AreEqual("09", clienteView.Numero);
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
            var result = controller.Create(GetNewCliente());

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
            var result = controller.Create(GetNewCliente());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ClienteViewModel));
            ClienteViewModel clienteView = (ClienteViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Yuri Alberto", clienteView.Nome);
            Assert.AreEqual("bagrealberto@gmail.com", clienteView.Email);
            Assert.AreEqual("14735834556", clienteView.Cpf);
            Assert.AreEqual("13999873456", clienteView.Telefone);
            Assert.AreEqual("49000499", clienteView.Cep);
            Assert.AreEqual("SE", clienteView.Estado);
            Assert.AreEqual("Itabaiana", clienteView.Cidade);
            Assert.AreEqual("Marianga", clienteView.Bairro);
            Assert.AreEqual("Gaviões da fiel", clienteView.Rua);
            Assert.AreEqual("09", clienteView.Numero);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            //Act
            var result = controller.Edit(GetTargetCliente().Id, GetTargetClienteViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ClienteViewModel));
            ClienteViewModel clienteView = (ClienteViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Yuri Alberto", clienteView.Nome);
            Assert.AreEqual("bagrealberto@gmail.com", clienteView.Email);
            Assert.AreEqual("14735834556", clienteView.Cpf);
            Assert.AreEqual("13999873456", clienteView.Telefone);
            Assert.AreEqual("49000499", clienteView.Cep);
            Assert.AreEqual("SE", clienteView.Estado);
            Assert.AreEqual("Itabaiana", clienteView.Cidade);
            Assert.AreEqual("Marianga", clienteView.Bairro);
            Assert.AreEqual("Gaviões da fiel", clienteView.Rua);
            Assert.AreEqual("09", clienteView.Numero);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetClienteViewModel().Id, GetTargetClienteViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ClienteViewModel GetNewCliente()
        {
            return new ClienteViewModel
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
                Numero = "06"
            };
        }

        private Pessoa GetTargetCliente()
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

        private ClienteViewModel GetTargetClienteViewModel()
        {
            return new ClienteViewModel
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
                Numero = "09"
            };
        }

        private IEnumerable<Pessoa> GetTestClientes()
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
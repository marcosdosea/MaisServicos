using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class ClienteServiceTests
    {
        private MaisServicosContext _context;
        private IClienteService _clienteService;

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
            var clientes = new List<Pessoa>
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
                    Id = 3,
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
            _context.AddRange(clientes);
            _context.SaveChanges();

            _clienteService = new ClienteService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //Act
            _clienteService.Create(new Pessoa
            {
                Id = 4,
                Nome = "Fabio Santos",
                Email = "tiochico@gmail.com",
                Cpf = "32748726487",
                Telefone = "87999871234",
                Cep = "53699455",
                Estado = "CE",
                Cidade = "Fortaleza",
                Bairro = "Invasão",
                Rua = "Fiel Macabra",
                Numero = "06"
            });

            //Assert
            Assert.AreEqual(4, _clienteService.GetAll().Count());
            var client = _clienteService.Get(4);
            Assert.AreEqual("Fabio Santos", client.Nome);
            Assert.AreEqual("tiochico@gmail.com", client.Email);
            Assert.AreEqual("32748726487", client.Cpf);
            Assert.AreEqual("87999871234", client.Telefone);
            Assert.AreEqual("53699455", client.Cep);
            Assert.AreEqual("CE", client.Estado);
            Assert.AreEqual("Fortaleza", client.Cidade);
            Assert.AreEqual("Invasão", client.Bairro);
            Assert.AreEqual("Fiel Macabra", client.Rua);
            Assert.AreEqual("06", client.Numero);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Act
            _clienteService.Delete(2);
            //Assert
            Assert.AreEqual(2, _clienteService.GetAll().Count());
            var client = _clienteService.Get(2);
            Assert.AreEqual(null, client);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act
            var client = _clienteService.Get(3);
            client.Nome = "Carlos Miguel";
            client.Email = "eternoreserva@gmail.com";
            client.Numero = "22";
            _clienteService.Edit(client);

            //Assert
            client = _clienteService.Get(3);
            Assert.IsNotNull(client);
            Assert.AreEqual("Carlos Miguel", client.Nome);
            Assert.AreEqual("eternoreserva@gmail.com", client.Email);
            Assert.AreEqual("22", client.Numero);
        }

        [TestMethod()]
        public void GetTest()
        {
            var client = _clienteService.Get(1);
            Assert.IsNotNull(client);
            Assert.AreEqual("Yuri Alberto", client.Nome);
            Assert.AreEqual("bagrealberto@gmail.com", client.Email);
            Assert.AreEqual("14735834556", client.Cpf);
            Assert.AreEqual("13999873456", client.Telefone);
            Assert.AreEqual("49000499", client.Cep);
            Assert.AreEqual("SE", client.Estado);
            Assert.AreEqual("Itabaiana", client.Cidade);
            Assert.AreEqual("Marianga", client.Bairro);
            Assert.AreEqual("Gaviões da fiel", client.Rua);
            Assert.AreEqual("09", client.Numero);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Act
            var listaClient = _clienteService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaClient, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listaClient);
            Assert.AreEqual(3, listaClient.Count());
            Assert.AreEqual(1, listaClient.First().Id);
            Assert.AreEqual("Yuri Alberto", listaClient.First().Nome);
        }
    }
}
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class PrestadorServiceTests
    {
        private MaisServicosContext _context;
        private IPrestadorService _prestadorService;

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
            var prestadores = new List<Pessoa>
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
                    Numero = "09",
                    TipoPessoa = "prestador"
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
                    Numero = "08",
                    TipoPessoa = "prestador"
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
                    Numero = "12",
                    TipoPessoa = "prestador"
                }
            };
            _context.AddRange(prestadores);
            _context.SaveChanges();

            _prestadorService = new PrestadorService(_context);
        }


        [TestMethod()]
        public void CreateTest()
        {
            //Act
            _prestadorService.Create(new Pessoa
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
                Numero = "06",
                TipoPessoa = "prestador"
            });

            //Assert
            Assert.AreEqual(4, _prestadorService.GetAll().Count());
            var prestador = _prestadorService.Get(4);
            Assert.AreEqual("Fabio Santos", prestador.Nome);
            Assert.AreEqual("tiochico@gmail.com", prestador.Email);
            Assert.AreEqual("32748726487", prestador.Cpf);
            Assert.AreEqual("87999871234", prestador.Telefone);
            Assert.AreEqual("53699455", prestador.Cep);
            Assert.AreEqual("CE", prestador.Estado);
            Assert.AreEqual("Fortaleza", prestador.Cidade);
            Assert.AreEqual("Invasão", prestador.Bairro);
            Assert.AreEqual("Fiel Macabra", prestador.Rua);
            Assert.AreEqual("06", prestador.Numero);
            Assert.AreEqual("prestador", prestador.TipoPessoa);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Act
            _prestadorService.Delete(2);
            //Assert
            Assert.AreEqual(2, _prestadorService.GetAll().Count());
            var prestador = _prestadorService.Get(2);
            Assert.AreEqual(null, prestador);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act
            var prestador = _prestadorService.Get(3);
            prestador.Nome = "Carlos Miguel";
            prestador.Email = "eternoreserva@gmail.com";
            prestador.Numero = "22";
            _prestadorService.Edit(prestador);

            //Assert
            prestador = _prestadorService.Get(3);
            Assert.IsNotNull(prestador);
            Assert.AreEqual("Carlos Miguel", prestador.Nome);
            Assert.AreEqual("eternoreserva@gmail.com", prestador.Email);
            Assert.AreEqual("22", prestador.Numero);
        }

        [TestMethod()]
        public void GetTest()
        {
            var prestador = _prestadorService.Get(1);
            Assert.IsNotNull(prestador);
            Assert.AreEqual("Yuri Alberto", prestador.Nome);
            Assert.AreEqual("bagrealberto@gmail.com", prestador.Email);
            Assert.AreEqual("14735834556", prestador.Cpf);
            Assert.AreEqual("13999873456", prestador.Telefone);
            Assert.AreEqual("49000499", prestador.Cep);
            Assert.AreEqual("SE", prestador.Estado);
            Assert.AreEqual("Itabaiana", prestador.Cidade);
            Assert.AreEqual("Marianga", prestador.Bairro);
            Assert.AreEqual("Gaviões da fiel", prestador.Rua);
            Assert.AreEqual("09", prestador.Numero);
            Assert.AreEqual("prestador", prestador.TipoPessoa);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Act
            var listaPrestador = _prestadorService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaPrestador, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listaPrestador);
            Assert.AreEqual(3, listaPrestador.Count());
            Assert.AreEqual(1, listaPrestador.First().Id);
            Assert.AreEqual("Yuri Alberto", listaPrestador.First().Nome);
        }

    }
}
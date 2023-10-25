using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class ServicoServiceTests
    {
        private MaisServicosContext _context;
        private IServicoService _servicoService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<MaisServicosContext>();
            builder.UseInMemoryDatabase("MaisServicos");
            var options = builder.Options;

            _context = new MaisServicosContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var servicos = new List<Servico>
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
                }
            };

            _context.AddRange(servicos);
            _context.SaveChanges();

            _servicoService = new ServicoService(_context);
        }


        [TestMethod()]
        public void CreateTest()
        {
            //Act
            _servicoService.Create(new Servico() { Id = 4, Nome = "Jardins Vivos", Descricao = "Serviço de paisagismo e jardinagem para criar e manter jardins vibrantes e harmoniosos.", IdAreaDeAtuacao = 4 });

            //Assert
            Assert.AreEqual(4, _servicoService.GetAll().Count());
            var servico = _servicoService.Get(4);
            Assert.AreEqual("Jardins Vivos", servico.Nome);
            Assert.AreEqual("Serviço de paisagismo e jardinagem para criar e manter jardins vibrantes e harmoniosos.", servico.Descricao);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Act
            _servicoService.Delete(2);

            //Assert
            Assert.AreEqual(2, _servicoService.GetAll().Count());
            var servico = _servicoService.Get(2);
            Assert.AreEqual(null, servico);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act
            var servico = _servicoService.Get(3);
            servico.Nome = "Água azul";
            servico.Descricao = "Água que fica azul!";
            _servicoService.Edit(servico);

            //Assert
            servico = _servicoService.Get(3);
            Assert.IsNotNull(servico);
            Assert.AreEqual("Água azul", servico.Nome);
            Assert.AreEqual("Água que fica azul!", servico.Descricao);
        }

        [TestMethod()]
        public void GetTest()
        {
            //Act
            var servico = _servicoService.Get(1);

            //Assert
            Assert.IsNotNull(servico);
            Assert.AreEqual("Casa Nova Remodelada", servico.Nome);
            Assert.AreEqual("Renovação completa ou parcial de residências para modernizar e melhorar o espaço.", servico.Descricao);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Act
            var listaServico = _servicoService.GetAll();

            //Assert
            Assert.IsInstanceOfType(listaServico, typeof(IEnumerable<Servico>));
            Assert.IsNotNull(listaServico);
            Assert.AreEqual(3, listaServico.Count());
            Assert.AreEqual(1, listaServico.First().Id);
            Assert.AreEqual("Casa Nova Remodelada", listaServico.First().Nome);
        }

        [TestMethod()]
        public void GetByNameTest()
        {
            //Act
            var servicos = _servicoService.GetByName("Casa");

            //Assert
            Assert.IsNotNull(servicos);
            Assert.AreEqual(1, servicos.Count());
            Assert.AreEqual("Casa Nova Remodelada", servicos.First().Nome);
        }
    }
}
using Moq;
using seed_desafio_cdc_api.Features.CadastroAutor;

namespace seed_desafio_cdc_api_tests.Features.CadastroAutor
{
    public class AutorTest
    {
        private IAutorRepository DummyRepository => new Mock<IAutorRepository>().Object;

        [Fact]
        public void DeveLancarExcecaoQuandoNomeNuloOuEmbranco()
        {
            Assert.Throws<Exception>(() => new Autor(null, "email@teste.com", "Descricao válida", DummyRepository));
            Assert.Throws<Exception>(() => new Autor("", "email@teste.com", "Descricao válida", DummyRepository));
        }

        [Fact]
        public void DeveLancarExecaoQuandoEmailNuloOuEmbranco()
        {
            Assert.Throws<Exception>(() => new Autor("Nome válido", null, "Descricao válida", DummyRepository));
            Assert.Throws<Exception>(() => new Autor("Nome válido", "", "Descricao válida", DummyRepository));
        }

        [Fact]
        public void DeveLancarExecaoQuandoEmailInvalido()
        {
            Assert.Throws<Exception>(() => new Autor("Nome válido", "emailinvalido", "Descricao válida", DummyRepository));
        }

        [Fact]
        public void DeveLancarExecaoQuandoDescricaoNuloOuEmbranco()
        {
            Assert.Throws<Exception>(() => new Autor("Nome válido", "email@teste.com", null, DummyRepository));
            Assert.Throws<Exception>(() => new Autor("Nome válido", "email@teste.com", "", DummyRepository));
        }

        [Fact]
        public void DeveLancarExecaoQuandoDescricaoMaiorQue400Caracteres()
        {
            var descricao = new string('a', 401);
            Assert.Throws<Exception>(() => new Autor("Nome válido", "email@teste.com", descricao, DummyRepository));
        }

        [Fact]
        public void DeveLancarExecaoQuandoEmailJaCadastrado()
        {
            var repoMock = new Mock<IAutorRepository>();
            repoMock.Setup(r => r.EmailJaCadastrado(It.IsAny<string>())).Returns(true);

            Assert.Throws<Exception>(() => new Autor("Nome válido", "email@teste.com", "Descricao válida", repoMock.Object));
        }
    }
}

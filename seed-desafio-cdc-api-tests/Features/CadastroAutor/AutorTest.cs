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
            Assert.Throws<Exception>(() => new Autor(null, "email@teste.com", "Descricao válida"));
            Assert.Throws<Exception>(() => new Autor("", "email@teste.com", "Descricao válida"));
        }

        [Fact]
        public void DeveLancarExecaoQuandoEmailNuloOuEmbranco()
        {
            Assert.Throws<Exception>(() => new Autor("Nome válido", null, "Descricao válida"));
            Assert.Throws<Exception>(() => new Autor("Nome válido", "", "Descricao válida"));
        }

        [Fact]
        public void DeveLancarExecaoQuandoEmailInvalido()
        {
            Assert.Throws<Exception>(() => new Autor("Nome válido", "emailinvalido", "Descricao válida"));
        }

        [Fact]
        public void DeveLancarExecaoQuandoDescricaoNuloOuEmbranco()
        {
            Assert.Throws<Exception>(() => new Autor("Nome válido", "email@teste.com", null));
            Assert.Throws<Exception>(() => new Autor("Nome válido", "email@teste.com", ""));
        }

        [Fact]
        public void DeveLancarExecaoQuandoDescricaoMaiorQue400Caracteres()
        {
            var descricao = new string('a', 401);
            Assert.Throws<Exception>(() => new Autor("Nome válido", "email@teste.com", descricao));
        }

        [Fact]
        public void DeveLancarExecaoQuandoEmailJaCadastrado()
        {
            var repoMock = new Mock<IAutorRepository>();
            repoMock.Setup(r => r.EmailJaCadastrado(It.IsAny<string>())).Returns(true);

            Assert.Throws<Exception>(() => new Autor("Nome válido", "email@teste.com", "Descricao válida"));
        }
    }
}

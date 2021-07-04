using CondoManager.Application.Handlers.Bloco;
using CondoManager.CQS.Commands.Bloco;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Bloco
{
    public class CriarBlocoTest
    {
        [Fact]
        public async void DeveCriarBloco()
        {
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();
            var condomioRepsoitorioMock = new Mock<ICondominioRepositorio>();

            condomioRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Condominio());

            var handler = new CriarBlocoHandler(blocoRepsoitorioMock.Object, condomioRepsoitorioMock.Object);

            var resultado = await handler.Handle(new CriarBlocoComando() { Nome = "Bloco 1", IdCondominio = Guid.NewGuid() }, new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveCriarBlocoComBlocoInvalido()
        {
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();
            var condomioRepsoitorioMock = new Mock<ICondominioRepositorio>();

            condomioRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Condominio>(null);

            var handler = new CriarBlocoHandler(blocoRepsoitorioMock.Object, condomioRepsoitorioMock.Object);

            var resultado = await handler.Handle(new CriarBlocoComando() { Nome = "Bloco 1", IdCondominio = Guid.NewGuid() }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado, resultado.TipoResultado);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void NaoDeveCriarBlocoComDadosInvalidos(string nome)
        {
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();
            var condomioRepsoitorioMock = new Mock<ICondominioRepositorio>();

            condomioRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Condominio());

            var handler = new CriarBlocoHandler(blocoRepsoitorioMock.Object, condomioRepsoitorioMock.Object);

            var resultado = await handler.Handle(new CriarBlocoComando() { Nome = nome, IdCondominio = Guid.NewGuid() }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.InputInvalido, resultado.TipoResultado);
        }
    }
}

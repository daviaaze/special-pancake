using CondoManager.Application.Handlers.Bloco;
using CondoManager.CQS.Commands.Bloco;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Bloco
{
    public class AlterarBlocoTest
    {
        [Fact]
        public async void DeveAlterarBloco()
        {
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();

            blocoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Bloco());

            var handler = new AlterarBlocoHandler(blocoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new AlterarBlocoComando() { Nome = "Bloco 1", IdBloco = Guid.NewGuid() }, new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveAlterarBlocoComBlocoInvalido()
        {
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();

            blocoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Bloco>(null);

            var handler = new AlterarBlocoHandler(blocoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new AlterarBlocoComando() { Nome = "Bloco 1", IdBloco = Guid.NewGuid() }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado, resultado.TipoResultado);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void NaoDeveAlterarBlocoComDadosInvalidos(string nome)
        {
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();

            blocoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Bloco());

            var handler = new AlterarBlocoHandler(blocoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new AlterarBlocoComando() { Nome = nome, IdBloco = Guid.NewGuid() }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.InputInvalido, resultado.TipoResultado);
        }
    }
}

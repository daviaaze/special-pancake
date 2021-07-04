using CondoManager.Application.Handlers.Bloco;
using CondoManager.CQS.Commands.Bloco;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Bloco
{
    public class DeletarBlocoTest
    {
        [Fact]
        public async void DeveDeletarBloco()
        {
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();

            blocoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Bloco());

            var handler = new DeletarBlocoHandler(blocoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new DeletarBlocoComando(Guid.NewGuid()), new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveDeletarBlocoComBlocoInvalido()
        {
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();

            blocoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Bloco>(null);

            var handler = new DeletarBlocoHandler(blocoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new DeletarBlocoComando(Guid.NewGuid()), new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado, resultado.TipoResultado);
        }
    }
}

using CondoManager.Application.Handlers.Morador;
using CondoManager.CQS.Commands.Morador;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Morador
{
    public class DeletarMoradorTest
    {
        [Fact]
        public async void DeveDeletarMorador()
        {
            var moradorRepsoitorioMock = new Mock<IMoradorRepositorio>();

            moradorRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Morador());

            var handler = new DeletarMoradorHandler(moradorRepsoitorioMock.Object);

            var resultado = await handler.Handle(new DeletarMoradorComando(Guid.NewGuid()), new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveDeletarMoradorComMoradorInvalido()
        {
            var moradorRepsoitorioMock = new Mock<IMoradorRepositorio>();

            moradorRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Morador>(null);

            var handler = new DeletarMoradorHandler(moradorRepsoitorioMock.Object);

            var resultado = await handler.Handle(new DeletarMoradorComando(Guid.NewGuid()), new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado, resultado.TipoResultado);
        }
    }
}

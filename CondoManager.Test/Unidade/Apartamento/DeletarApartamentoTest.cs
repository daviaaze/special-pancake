using CondoManager.Application.Handlers.Apartamento;
using CondoManager.CQS.Commands.Apartamento;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Apartamento
{
    public class DeletarApartamentoTest
    {
        [Fact]
        public async void DeveDeletarApartamento()
        {
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();

            apartamentoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Apartamento());

            var handler = new DeletarApartamentoHandler(apartamentoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new DeletarApartamentoComando(Guid.NewGuid()), new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveDeletarApartamentoComBlocoInvalido()
        {
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();

            apartamentoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Apartamento>(null);

            var handler = new DeletarApartamentoHandler(apartamentoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new DeletarApartamentoComando(Guid.NewGuid()), new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado, resultado.TipoResultado);
        }
    }
}

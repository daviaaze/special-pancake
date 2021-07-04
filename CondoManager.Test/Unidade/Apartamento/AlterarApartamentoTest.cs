using CondoManager.Application.Handlers.Apartamento;
using CondoManager.CQS.Commands.Apartamento;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Apartamento
{
    public class AlterarApartamentoTest
    {
        [Fact]
        public async void DeveAlterarApartamento()
        {
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();

            apartamentoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Apartamento());

            var handler = new AlterarApartamentoHandler(apartamentoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new AlterarApartamentoComando() { Andar = 1, Numero = 101, IdApartamento = Guid.NewGuid() }, new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveAlterarApartamentoComBlocoInvalido()
        {
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();

            apartamentoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Apartamento>(null);

            var handler = new AlterarApartamentoHandler(apartamentoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new AlterarApartamentoComando() { Andar = 1, Numero = 101, IdApartamento = Guid.NewGuid() }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado, resultado.TipoResultado);
        }

        [Theory]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        public async void NaoDeveAlterarApartamentoComDadosInvalidos(int andar, int numero)
        {
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();

            apartamentoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Apartamento());

            var handler = new AlterarApartamentoHandler(apartamentoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new AlterarApartamentoComando() { Andar = andar, Numero = numero, IdApartamento = Guid.NewGuid() }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.InputInvalido, resultado.TipoResultado);
        }
    }
}

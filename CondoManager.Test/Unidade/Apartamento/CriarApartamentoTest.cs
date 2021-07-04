using CondoManager.Application.Handlers.Apartamento;
using CondoManager.CQS.Commands.Apartamento;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Apartamento
{
    public class CriarApartamentoTest
    {
        [Fact]
        public async void DeveCriarApartamento()
        {
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();

            blocoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Bloco());

            var handler = new CriarApartamentoHandler(apartamentoRepsoitorioMock.Object, blocoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new CriarApartamentoComando() { Andar = 1, Numero = 101, IdBloco = Guid.NewGuid() }, new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveCriarApartamentoComBlocoInvalido()
        {
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();

            blocoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Bloco>(null);

            var handler = new CriarApartamentoHandler(apartamentoRepsoitorioMock.Object, blocoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new CriarApartamentoComando() { Andar = 1, Numero = 101, IdBloco = Guid.NewGuid() }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado, resultado.TipoResultado);
        }

        [Theory]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        public async void NaoDeveCriarApartamentoComDadosInvalidos(int andar, int numero)
        {
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();
            var blocoRepsoitorioMock = new Mock<IBlocoRepositorio>();

            blocoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Bloco());

            var handler = new CriarApartamentoHandler(apartamentoRepsoitorioMock.Object, blocoRepsoitorioMock.Object);

            var resultado = await handler.Handle(new CriarApartamentoComando() { Andar = andar, Numero = numero, IdBloco = Guid.NewGuid() }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.InputInvalido, resultado.TipoResultado);
        }
    }
}

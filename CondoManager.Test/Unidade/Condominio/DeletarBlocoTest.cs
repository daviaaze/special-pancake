using CondoManager.Application.Handlers.Condominio;
using CondoManager.CQS.Commands.Condominio;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Condominio
{
    public class DeletarCondominioTest
    {
        [Fact]
        public async void DeveDeletarCondominio()
        {
            var condominioRepsoitorioMock = new Mock<ICondominioRepositorio>();

            condominioRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Condominio());

            var handler = new DeletarCondominioHandler(condominioRepsoitorioMock.Object);

            var resultado = await handler.Handle(new DeletarCondominioComando(Guid.NewGuid()), new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveDeletarCondominioComCondominioInvalido()
        {
            var condominioRepsoitorioMock = new Mock<ICondominioRepositorio>();

            condominioRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Condominio>(null);

            var handler = new DeletarCondominioHandler(condominioRepsoitorioMock.Object);

            var resultado = await handler.Handle(new DeletarCondominioComando(Guid.NewGuid()), new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado, resultado.TipoResultado);
        }
    }
}

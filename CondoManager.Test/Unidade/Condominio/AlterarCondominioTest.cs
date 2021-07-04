using CondoManager.Application.Handlers.Condominio;
using CondoManager.CQS.Commands.Condominio;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Condominio
{
    public class AlterarCondominioTest
    {
        [Fact]
        public async void DeveAlterarCondominio()
        {
            var condominioRepsoitorioMock = new Mock<ICondominioRepositorio>();

            condominioRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Condominio());

            var handler = new AlterarCondominioHandler(condominioRepsoitorioMock.Object);

            var resultado = await handler.Handle(new AlterarCondominioComando() { Nome = "Condominio 1", Telefone = "14996673487", EmailSindico = "daviaaze@gmail.com", IdCondominio = Guid.NewGuid() }, new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveAlterarCondominioComCondominioInvalido()
        {
            var condominioRepsoitorioMock = new Mock<ICondominioRepositorio>();

            condominioRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Condominio>(null);

            var handler = new AlterarCondominioHandler(condominioRepsoitorioMock.Object);

            var resultado = await handler.Handle(new AlterarCondominioComando() { Nome = "Condominio 1", Telefone = "14996673487", EmailSindico = "daviaaze@gmail.com", IdCondominio = Guid.NewGuid() }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado, resultado.TipoResultado);
        }

        [Theory]
        [InlineData(null, "14996673487", "daviaaze@gmail.com")]
        [InlineData("Davi Azevedo", "149963487", "daviaaze@gmail.com")]
        [InlineData("Davi Azevedo", "14996673487", "daviaazegmail")]
        public async void NaoDeveAlterarCondominioComDadosInvalidos(string nome, string telefone, string emailSindico)
        {
            var condominioRepsoitorioMock = new Mock<ICondominioRepositorio>();

            condominioRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Condominio());

            var handler = new AlterarCondominioHandler(condominioRepsoitorioMock.Object);

            var resultado = await handler.Handle(new AlterarCondominioComando() { Nome = nome, Telefone = telefone, EmailSindico = emailSindico, IdCondominio = Guid.NewGuid() }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.InputInvalido, resultado.TipoResultado);
        }
    }
}

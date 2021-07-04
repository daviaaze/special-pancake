using CondoManager.Application.Handlers.Condominio;
using CondoManager.CQS.Commands.Condominio;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Condominio
{
    public class CriarCondominioTest
    {
        [Fact]
        public async void DeveCriarCondominio()
        {
            var condominioRepsoitorioMock = new Mock<ICondominioRepositorio>();

            condominioRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Condominio());

            var handler = new CriarCondominioHandler(condominioRepsoitorioMock.Object);

            var resultado = await handler.Handle(new CriarCondominioComando() { Nome = "Condominio 1", EmailSindico = "daviaaze@gmail.com", Telefone = "14996673487" }, new CancellationToken());

            Assert.True(resultado.Sucesso);
        }


        [Theory]
        [InlineData(null, "14996673487", "daviaaze@gmail.com")]
        [InlineData("Davi Azevedo", "149963487", "daviaaze@gmail.com")]
        [InlineData("Davi Azevedo", "14996673487", "daviaaze@gmail")]
        public async void NaoDeveCriarCondominioComDadosInvalidos(string nome, string emailSindico, string telefone)
        {
            var condominioRepsoitorioMock = new Mock<ICondominioRepositorio>();
            var condomioRepsoitorioMock = new Mock<ICondominioRepositorio>();

            condominioRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Condominio());

            var handler = new CriarCondominioHandler(condominioRepsoitorioMock.Object);

            var resultado = await handler.Handle(new CriarCondominioComando() { Nome = nome, EmailSindico = emailSindico, Telefone = telefone }, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.InputInvalido, resultado.TipoResultado);
        }
    }
}

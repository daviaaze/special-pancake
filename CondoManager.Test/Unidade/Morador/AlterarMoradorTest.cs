using CondoManager.Application.Handlers.Morador;
using CondoManager.CQS.Commands.Morador;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Morador
{
    public class AlterarMoradorTest
    {
        [Fact]
        public async void DeveAlterarMorador()
        {
            var moradorRepsoitorioMock = new Mock<IMoradorRepositorio>();

            moradorRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Morador());

            var handler = new AlterarMoradorHandler(moradorRepsoitorioMock.Object);

            var comando = new AlterarMoradorComando()
            {
                Nome = "Davi Azevedo",
                Cpf = "04510027176",
                DataNascimento = DateTime.Now.AddYears(-21),
                Email = "daviaaze@gmail.com",
                Telefone = "14996673487",
                IdMorador = Guid.NewGuid()
            };

            var resultado = await handler.Handle(comando, new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveAlterarMoradorComMoradorInvalido()
        {
            var moradorRepsoitorioMock = new Mock<IMoradorRepositorio>();

            moradorRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Morador>(null);

            var handler = new AlterarMoradorHandler(moradorRepsoitorioMock.Object);

            var comando = new AlterarMoradorComando()
            {
                Nome = "Davi Azevedo",
                Cpf = "04510027176",
                DataNascimento = DateTime.Now.AddYears(-21),
                Email = "daviaaze@gmail.com",
                Telefone = "14996673487",
                IdMorador = Guid.NewGuid()
            };

            var resultado = await handler.Handle(comando, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado, resultado.TipoResultado);
        }

        [Theory]
        [InlineData(null, "04510027176", "1999-11-20", "daviaaze@gmail.com", "14996673487")]
        [InlineData("Davi Azevedo", "0451027176", "1999-11-20", "daviaaze@gmail.com", "14996673487")]
        [InlineData("Davi Azevedo", "04510027176", "2008-11-20", "daviaaze@gmail.com", "14996673487")]
        [InlineData("Davi Azevedo", "04510027176", "1999-11-20", "daviaaze", "14996673487")]
        [InlineData("Davi Azevedo", "04510027176", "1999-11-20", "daviaaze@gmail.com", "14996487")]
        public async void NaoDeveAlterarMoradorComDadosInvalidos(string nome, string cpf, DateTime dataNascimento, string email, string telefone)
        {
            var moradorRepsoitorioMock = new Mock<IMoradorRepositorio>();

            moradorRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Morador());

            var handler = new AlterarMoradorHandler(moradorRepsoitorioMock.Object);

            var comando = new AlterarMoradorComando()
            {
                Nome = nome,
                Cpf = cpf,
                DataNascimento = dataNascimento,
                Email = email,
                Telefone = telefone,
                IdMorador = Guid.NewGuid()
            };

            var resultado = await handler.Handle(comando, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.InputInvalido, resultado.TipoResultado);
        }
    }
}

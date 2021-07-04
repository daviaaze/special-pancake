using CondoManager.Application.Handlers.Morador;
using CondoManager.CQS.Commands.Morador;
using CondoManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CondoManager.Test.Unidade.Morador
{
    public class CriarMoradorTest
    {
        [Fact]
        public async void DeveCriarMorador()
        {
            var moradorRepsoitorioMock = new Mock<IMoradorRepositorio>();
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();

            apartamentoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns(new Domain.Entidades.Apartamento());

            var handler = new CriarMoradorHandler(moradorRepsoitorioMock.Object, apartamentoRepsoitorioMock.Object);

            var comando = new CriarMoradorComando()
            {
                Nome = "Davi Azevedo",
                Cpf = "04510027176",
                DataNascimento = DateTime.Now.AddYears(-21),
                Email = "daviaaze@gmail.com",
                Telefone = "14996673487",
                IdApartamento = Guid.NewGuid()
            };

            var resultado = await handler.Handle(comando, new CancellationToken());

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public async void NaoDeveCriarMoradorComApartamentoInvalido()
        {
            var moradorRepsoitorioMock = new Mock<IMoradorRepositorio>();
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();

            apartamentoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Apartamento>(null);

            var handler = new CriarMoradorHandler(moradorRepsoitorioMock.Object, apartamentoRepsoitorioMock.Object);

            var comando = new CriarMoradorComando()
            {
                Nome = "Davi Azevedo",
                Cpf = "04510027176",
                DataNascimento = DateTime.Now.AddYears(-21),
                Email = "daviaaze@gmail.com",
                Telefone = "14996673487",
                IdApartamento = Guid.NewGuid()
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
        public async void NaoDeveCriarMoradorComDadosInvalidos(string nome, string cpf, DateTime dataNascimento, string email, string telefone)
        {
            var moradorRepsoitorioMock = new Mock<IMoradorRepositorio>();
            var apartamentoRepsoitorioMock = new Mock<IApartamentoRepositorio>();

            apartamentoRepsoitorioMock.Setup(d => d.Find(It.IsAny<Guid>())).Returns<Domain.Entidades.Apartamento>(null);

            var handler = new CriarMoradorHandler(moradorRepsoitorioMock.Object, apartamentoRepsoitorioMock.Object);

            var comando = new CriarMoradorComando()
            {
                Nome = nome,
                Cpf = cpf,
                DataNascimento = dataNascimento,
                Email = email,
                Telefone = telefone,
                IdApartamento = Guid.NewGuid()
            };

            var resultado = await handler.Handle(comando, new CancellationToken());

            Assert.False(resultado.Sucesso);
            Assert.Equal(Domain.Core.Enums.EnumTipoResultado.InputInvalido, resultado.TipoResultado);
        }
    }
}

using System.ComponentModel;

namespace CondoManager.Domain.Core.Enums
{
    public enum EnumTipoResultado
    {
        [Description("OK")]
        Ok,

        [Description("Criado")]
        Criado,

        [Description("Aceito")]
        Aceito,

        [Description("Entrada Inválida")]
        InputInvalido,

        [Description("Não Encontrado")]
        NaoEncontrado,

        [Description("Proibido")]
        Proibido,

        [Description("Erro Interno")]
        ErroInterno,

        [Description("Serviço Indisponível")]
        ServicoIndisponivel
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

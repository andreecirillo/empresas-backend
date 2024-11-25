using System.ComponentModel;

namespace Empresas.Domain.Enums
{
    public class EmpresaEnums
    {
        public enum PorteEmpresa
        {
            [Description("Pequeno")]
            Pequeno = 1,
            [Description("Médio")]
            Medio = 2,
            [Description("Grande")]
            Grande = 3
        }
    }
}

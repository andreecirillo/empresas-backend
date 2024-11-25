using static Empresas.Domain.Enums.EmpresaEnums;

namespace Empresas.API.Models
{
    public class EmpresaCreateDTO
    {
        public required string Nome { get; set; }
        public required PorteEmpresa Porte { get; set; }        
    }
}

using static Empresas.Domain.Enums.EmpresaEnums;

namespace Empresas.API.Models
{
    public class EmpresaUpdateDTO
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required PorteEmpresa Porte { get; set; }        
    }
}

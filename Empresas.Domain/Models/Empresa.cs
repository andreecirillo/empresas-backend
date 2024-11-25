using static Empresas.Domain.Enums.EmpresaEnums;

namespace Empresas.Domain.Models
{
    public class Empresa
    {
        public virtual int Id { get; set; }
        public virtual string? Nome { get; set; }
        public virtual PorteEmpresa Porte { get; set; }
    }
}
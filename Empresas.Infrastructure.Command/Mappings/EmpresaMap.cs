using Empresas.Domain.Models;
using FluentNHibernate.Mapping;

public class EmpresaMap : ClassMap<Empresa>
{
    public EmpresaMap()
    {
        Table("Empresa");
        Id(x => x.Id).GeneratedBy.Identity();
        Map(x => x.Nome).Length(255).Not.Nullable();
        Map(x => x.Porte).CustomType<int>().Not.Nullable();
    }
}

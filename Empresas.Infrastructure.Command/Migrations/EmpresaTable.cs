using FluentMigrator;

namespace Empresas.Infrastructure.Command.Migrations
{
    [Migration(2024112501)]
    public class EmpresaTable : Migration
    {
        public override void Up()
        {
            if (!Schema.Table("Empresa").Exists())
            {
                Create.Table("Empresa")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(255).NotNullable()
                .WithColumn("Porte").AsInt32().NotNullable();
            }
        }

        public override void Down()
        {
            Delete.Table("Empresa");
        }
    }
}

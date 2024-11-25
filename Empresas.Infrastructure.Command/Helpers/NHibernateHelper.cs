using FluentNHibernate.Cfg;
using NHibernate;

public class NHibernateHelper
{
    private readonly ISessionFactory _sessionFactory;

    public NHibernateHelper(string connectionString)
    {
        _sessionFactory = Fluently.Configure()
            .Database(() => FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmpresaMap>())
            .ExposeConfiguration(cfg =>
            {
                cfg.SetProperty(NHibernate.Cfg.Environment.UseSecondLevelCache, "false");
            })
            .BuildSessionFactory();
    }

    public ISession OpenSession()
    {
        return _sessionFactory.OpenSession();
    }
}







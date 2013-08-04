using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using WhiteBorad.Models;

namespace WhiteBorad.DBFactory
{
    public class DBfactory
    {
         public static ISession GetSession()
            {
                const string sqlConnectionString =
                    "Data Source=localhost;Initial Catalog=Whiteboard;Integrated Security=True;Enlist=false;";
                var msSqlConfiguration =
                    MsSqlConfiguration.MsSql2008.ConnectionString(sqlConnectionString)
                                      .Raw("connection.release_mode", "on_close");
                return Fluently.Configure().Database(msSqlConfiguration).Mappings(
                    config => config.FluentMappings.AddFromAssembly(typeof (Person).Assembly)).BuildSessionFactory().OpenSession();

            }
         
    }
}

 

      


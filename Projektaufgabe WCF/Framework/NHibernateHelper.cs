using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;

namespace Projektaufgabe_WCF.Framework
{
    public static class NHibernateHelper
    {
        private static ISessionFactory mSessionFactory;
        public static string DatabaseFile { get; set; }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (mSessionFactory == null)
                    InitializeSessionFactory();
                return mSessionFactory;
            }
        }

        public static ISession OpenSession() => SessionFactory.OpenSession();

        private static void InitializeSessionFactory()
        {
            mSessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(DatabaseFile).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(DefaultLazy.Never()))
                .BuildSessionFactory();
        }
    }
}
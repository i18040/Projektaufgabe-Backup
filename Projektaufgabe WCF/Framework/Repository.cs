using System;
using System.Collections.Generic;
using Projektaufgabe_WCF.Interfaces;

namespace Projektaufgabe_WCF.Framework
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(string databaseFile) => NHibernateHelper.DatabaseFile = databaseFile;

        public List<T> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.CreateCriteria<T>().List<T>();
                return returnList as List<T>;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(entity);
                        transaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save(T entity)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(entity);
                        transaction.Commit();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool Update(T entity)
        {
            try { 
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Update(entity);
                        transaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
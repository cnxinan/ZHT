using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using ZHT.Core.UnitOfWork;
using ZHT.Data.DbFactory;
using ZHT.Data.Models;
using System.Data.Entity.Validation;

namespace ZHT.Repository.Base
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private readonly IDataBaseFactory _dataBaseFactory;
        private ZHTDataContext context;


        public BaseUnitOfWork(IDataBaseFactory dataBaseFactory)
        {
            _dataBaseFactory = dataBaseFactory;
        }

        protected ZHTDataContext Context
        {
            get { return context ?? (context = _dataBaseFactory.GetDataBase()); }
        }

        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
            return msg;
        }

        public void Commint()
        {
            try
            {
                Context.SaveChanges();

            }
            catch (DbEntityValidationException dbEx) {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }


        public void CommintTransaction()
        {
            var trans = Context.Database.BeginTransaction();
            try
            {
                Context.SaveChanges();
                trans.Commit();

            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
            catch (System.Exception ex)
            {
                trans.Rollback();
                throw ex;
            }

        }
        public void Rollback()
        {
            Context.Database.BeginTransaction().Rollback();
        }

    }
}

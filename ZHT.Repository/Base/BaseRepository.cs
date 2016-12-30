using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using ZHT.Core.Repository;
using ZHT.Data.DbFactory;
using ZHT.Data.Models;
using System.Data.Entity.Validation;

namespace ZHT.Repository.Base
{
    public abstract class BaseRepository<T> : IRepositoryAsync<T> where T : class
    {
        private ZHTDataContext dataContext;
        private DbSet<T> dbSet;

        /// <summary>
        /// 获取实体
        /// </summary>
        public IQueryable<T> Table
        {
            get { return Entities; }
        }
        public IQueryable<T> TableAsNoTracking
        {
            get { return Entities.AsNoTracking(); }
        }

        protected DbSet<T> Entities
        {
            get
            {
                return dbSet;
            }
        }

        public BaseRepository(IDataBaseFactory dataBaseFactory)
        {
            DatabaseFactory = dataBaseFactory;
            dbSet = DataContext.Set<T>();

        }

        protected IDataBaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected ZHTDataContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.GetDataBase()); }
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            dbSet.Add(entity);
        }

        //public virtual int Add(crm_membership_card entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException("entity");
        //    dataContext.crm_membership_card.Add(entity);
        //    return entity.membership_card_id;
        //}

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void Update(T entity)
        {       
            if (entity == null)
                throw new ArgumentNullException("Update entity is null");
            dbSet.Attach(entity);
            this.DataContext.Entry(entity).State = EntityState.Modified;  
        }
        /// <summary>
        ///  删除实体 
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Delete entity is null");
            dbSet.Attach(entity);
            dbSet.Remove(entity);  
        }

        /// <summary>
        ///  逻辑删除实体 
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void LogicalDelete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Update entity is null");
            Update(entity);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>T</returns>
        public virtual T GetById(object Id)
        {
            return this.Entities.Find(Id);
        }
        /// <summary>
        /// 根据查询过滤条件获取实体
        /// </summary>
        /// <param name="where">查询表达式</param>
        /// <returns>T</returns>
        public virtual T GetEntiny(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
        /// <summary>
        /// 预加载实体的集合
        /// </summary>
        /// <param name="where">查询表达式</param>
        /// <returns>IQueryable T</returns>
        public virtual IQueryable<T> Preload(Expression<Func<T, bool>> where)
        {

            return dbSet.Include(where);
        }
        /// <summary>
        /// 根据查询过滤条件获取实体集合
        /// </summary>
        /// <param name="where">查询表达式</param>
        /// <returns>IQueryableT</returns>
        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public virtual void ExecuteSql(string sql, params object[] parameters)
        {
            this.dataContext.Database.ExecuteSqlCommand(sql, parameters);
            this.DataContext.SaveChanges();

        }

        public virtual IEnumerable<T> SearchBySql(string sql, params object[] parameters)
        {
            return this.dataContext.Database.SqlQuery<T>(sql, parameters).AsEnumerable<T>();
        }

        public virtual async System.Threading.Tasks.Task<T> FindAsync(params object[] keyValues)
        {
            return await dbSet.FindAsync(keyValues);
        }

        public virtual async System.Threading.Tasks.Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}

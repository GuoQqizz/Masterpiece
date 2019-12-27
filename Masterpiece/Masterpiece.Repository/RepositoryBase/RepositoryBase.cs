using Masterpiece.Code.Common;
using Masterpiece.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Masterpiece.Repository.RepositoryBase
{
    /// <summary>
    /// 仓储实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryBase<TContext, TEntity> where TEntity : class, new() where TContext : DbContext, new()
    {
        protected TContext dbcontext;
        protected string tranId;

        public string TranId
        {
            set; get;
        }

        protected RepositoryBase(TContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        protected virtual List<TEntity> AllEntities()
        {
            return dbcontext.Set<TEntity>().ToList();
        }

        protected virtual int DeleteEntity(TEntity entity)
        {
            try
            {
                if (entity is ICaching<TEntity>)
                {
                    TEntity existingEntity = dbcontext.Set<TEntity>().Local.FirstOrDefault(((ICaching<TEntity>)entity).CheckInLocal());
                    if (existingEntity != null)
                    {
                        dbcontext.Entry(existingEntity).State = EntityState.Detached;
                    }
                }

                dbcontext.Set<TEntity>().Attach(entity);
                dbcontext.Entry<TEntity>(entity).State = EntityState.Deleted;
                return dbcontext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return 0;
            }
        }

        protected virtual int DeleteEntity(Expression<Func<TEntity, bool>> predicate)
        {
            var entitys = dbcontext.Set<TEntity>().Where(predicate).ToList();
            entitys.ForEach(m => dbcontext.Entry<TEntity>(m).State = EntityState.Deleted);
            return dbcontext.SaveChanges();
        }

        protected virtual TEntity FindEntity(int keyValue)
        {
            return dbcontext.Set<TEntity>().Find(keyValue);
        }

        protected virtual TEntity FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return dbcontext.Set<TEntity>().FirstOrDefault(predicate);
        }

        protected List<TEntity> FindList(string strSql)
        {
            return dbcontext.Database.SqlQuery<TEntity>(strSql).ToList<TEntity>();
        }

        protected virtual List<TEntity> FindList(string strSql, DbParameter[] dbParameter)
        {
            return dbcontext.Database.SqlQuery<TEntity>(strSql, dbParameter).ToList<TEntity>();
        }

        protected virtual int InsertEntity(TEntity entity)
        {
            dbcontext.Entry<TEntity>(entity).State = EntityState.Added;
            return dbcontext.SaveChanges();
        }

        protected virtual int InsertEntity(List<TEntity> entitys)
        {
            foreach (var entity in entitys)
            {
                dbcontext.Entry<TEntity>(entity).State = EntityState.Added;
            }
            return dbcontext.SaveChanges();
        }

        protected virtual IQueryable<TEntity> IQueryable()
        {
            return dbcontext.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return dbcontext.Set<TEntity>().Where(predicate);
        }

        protected virtual List<T> Paging<T>(string fields,
            string where,
            string orderby, PagingObject paging, object param = null) where T : class
        {
            string pagingTemplate = @"WITH PagingSet AS
                                   (
                                      SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS RowNum,{1} from {2}
                                    )
                                    SELECT * FROM PagingSet WHERE RowNum BETWEEN {3} AND {4} ;";

            string totalCountTemplate = @"declare @total int;
                                          set @total = (select COUNT(1) from {0});
                                          select @total; ";

            List<SqlParameter> paramArray = new List<SqlParameter>();
            List<SqlParameter> paramArray1 = new List<SqlParameter>();
            if (param != null)
            {
                PropertyInfo[] ps = param.GetType().GetProperties();
                foreach (PropertyInfo property in ps)
                {
                    string name = property.Name;
                    object value = property.GetValue(param);
                    if (value != null)
                    {
                        SqlParameter sqlParam = new SqlParameter(name, value);
                        SqlParameter sqlParam1 = new SqlParameter(name, value);
                        paramArray.Add(sqlParam);
                        paramArray1.Add(sqlParam1);
                    }
                }
            }

            paging.TotalCount = dbcontext.Database.SqlQuery<int>(string.Format(totalCountTemplate, where), paramArray.ToArray()).FirstOrDefault();

            var sql = string.Format(pagingTemplate, orderby, fields, where, (paging.PageIndex - 1) * paging.PageSize + 1, paging.PageIndex * paging.PageSize);
            return dbcontext.Database.SqlQuery<T>(sql, paramArray1.ToArray()).ToList();
        }

        protected virtual int SaveChanges()
        {
            return dbcontext.SaveChanges();
        }

        protected virtual int UpdateEntity(TEntity entity)
        {
            if (entity is ICaching<TEntity>)
            {
                TEntity existingEntity = dbcontext.Set<TEntity>().Local.FirstOrDefault(((ICaching<TEntity>)entity).CheckInLocal());
                if (existingEntity != null)
                {
                    dbcontext.Entry(existingEntity).State = EntityState.Detached;
                }
            }

            dbcontext.Set<TEntity>().Attach(entity);
            PropertyInfo[] props = entity.GetType().GetProperties();
            if (entity is IChangeTrack && ((IChangeTrack)entity).IsEnableAudit())
            {
                List<string> changeFields = ((IChangeTrack)entity).ChangedFields();
                if (changeFields.Count > 0)
                {
                    props = props.Where(x => changeFields.Contains(x.Name)).ToArray();
                }
                else
                {
                    return 0;
                }
            }
            foreach (PropertyInfo prop in props)
            {
                dbcontext.Entry(entity).Property(prop.Name).IsModified = true;
            }
            return dbcontext.SaveChanges();
        }
    }
}
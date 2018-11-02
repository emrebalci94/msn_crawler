using MsnCrawler.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MsnCrawler.Common.DataAccess
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Verilen datayı database objesine insert işlemi yapar.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(T entity);
        /// <summary>
        /// Verilen datayı birden fazla database objesine insert işlemi yapar.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(List<T> entity);
        /// <summary>
        /// Verilen datayı database objesine update işlemi yapar.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(T entity);
        /// <summary>
        /// Verilen datayı database objesine delete işlemi yapar.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(T entity);
        /// <summary>
        /// Verilen datayı birden fazla database objesine delete işlemi yapar.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(List<T> entity);
        /// <summary>
        /// Bütün veriyi veritabanından çeker.
        /// </summary>
        /// <returns></returns>
        List<T> GetList();
        /// <summary>
        /// Verilen filtreye göre ait bütün verileri çeker.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        List<T> GetList(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Verilen filtreye ait tek veri döner
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Datanın sql karşılığını çeker.Yani daha veritabanına istek atılmamış hali.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetQueryable();
        /// <summary>
        /// Queryable getirirken ayrıca gelmesini istediğiniz (birbiriyle ilişkili) tabloyu getirir.
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<T> GetIncludes(params Expression<Func<T, object>>[] includes);
        /// <summary>
        /// Verilen filtreye göre: datanın sql karşılığını çeker.Yani daha veritabanına istek atılmamış hali.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> where);
        /// <summary>
        /// Verilen filtreye göre verinin olup olmadığını döner.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> where);
        /// <summary>
        /// Verilen id ye göre verinin var olup olmadığına bakar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool HasById(int id);
        /// <summary>
        /// Verilen id'ye göre objeyi geri döner.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);
    }

}

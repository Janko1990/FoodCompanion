using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		DbContext Context { get; }

		IQueryable<T> AsQueryable();
		IQueryable<T> GetAll();
		IEnumerable<T> Where( Expression<Func<T, bool>> predicate );
		bool Any( Expression<Func<T, bool>> predicate );
		T Single( Expression<Func<T, bool>> predicate );
		T SingleOrDefault( Expression<Func<T, bool>> predicate );
		T First( Expression<Func<T, bool>> predicate );
		T FirstOrDefault( Expression<Func<T, bool>> predicate );
		T GetByID( int id );
		void Add( T entity );
		void Delete( T entity );
		void Delete( object id );
		void Update( T entity );
		void Attach( T entity );
	}
}

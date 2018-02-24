using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DAL
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly DbContext context;
		protected readonly DbSet<T> dbSet;

		public GenericRepository( DbContext context )
		{
			this.context = context;
			this.dbSet = context.Set<T>();
		}

		public DbContext Context
		{
			get
			{
				return this.context;
			}
		}

		public void Add( T entity )
		{
			this.dbSet.Add( entity );
		}

		public bool Any( Expression<Func<T, bool>> predicate )
		{
			return this.dbSet.Any( predicate );
		}

		public IQueryable<T> AsQueryable()
		{
			return this.dbSet.AsQueryable();
		}

		public void Attach( T entity )
		{
			this.dbSet.Attach( entity );
		}

		public void Delete( object id )
		{
			var entityToDelete = this.dbSet.Find( id );
			this.Delete( entityToDelete );
		}

		public void Delete( T entity )
		{
			this.dbSet.Remove( entity );
		}

		public T First( Expression<Func<T, bool>> predicate )
		{
			return this.dbSet.First( predicate );
		}

		public T FirstOrDefault( Expression<Func<T, bool>> predicate )
		{
			return this.dbSet.FirstOrDefault( predicate );
		}

		public IQueryable<T> GetAll()
		{
			return this.dbSet;
		}

		public T GetByID( int id )
		{
			return this.dbSet.Find( id );
		}

		public T Single( Expression<Func<T, bool>> predicate )
		{
			return this.dbSet.Single( predicate );
		}

		public T SingleOrDefault( Expression<Func<T, bool>> predicate )
		{
			return this.dbSet.SingleOrDefault( predicate );
		}

		public void Update( T entity )
		{
			this.dbSet.Attach( entity );
			context.Entry( entity ).State = EntityState.Modified;
		}

		public IEnumerable<T> Where( Expression<Func<T, bool>> predicate )
		{
			return this.dbSet.Where( predicate );
		}
	}
}

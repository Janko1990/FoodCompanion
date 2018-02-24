using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		#region Members

		private FoodCompanionContext context;
		private DbContextTransaction transaction = null;

		private IGenericRepository<Meal> mealRepository;
		private IGenericRepository<MealCategory> mealCategoryRepository;
		private IGenericRepository<MealProduct> mealProductRepository;
		private IGenericRepository<Product> productRepository;
		private IGenericRepository<ProductCategory> productCategoryRepository;
		private IGenericRepository<Shop> shopRepository;
		private IGenericRepository<ShopProduct> shopProductRepository;

		#endregion Members
		
		#region Properties

		public static string ConnectionString { get; set; }
		
		#endregion Properties

		#region Ctor

		public UnitOfWork()
		{
			if ( string.IsNullOrEmpty( ConnectionString ) )
				throw new Exception( "ConnectionString is empty" );

			this.context = new FoodCompanionContext( ConnectionString );
		}

		#endregion Ctor

		#region Methods

		public void CreateNewDatabase()
		{
			this.context.Database.Create();
		}

		public void BeginTransaction( IsolationLevel isolationLevel )
		{
			if ( transaction != null )
				throw new InvalidOperationException( "Transaction is already stared." );

			transaction = this.context.Database.BeginTransaction( isolationLevel );
		}

		public void RollbackTransaction()
		{
			if ( transaction == null )
				throw new InvalidOperationException( "Transaction has not been stared." );

			transaction.Rollback();
		}

		public void CommitTransaction()
		{
			if ( transaction == null )
				throw new InvalidOperationException( "Transaction has not been stared." );

			transaction.Commit();
		}

		#endregion Methods

		#region IUnitOfWork

		#region Repositories

		public IGenericRepository<Meal> MealRepository
		{
			get
			{
				if ( this.mealRepository == null )
					this.mealRepository = new GenericRepository<Meal>( this.context );
				return this.mealRepository;
			}
		}

		public IGenericRepository<MealCategory> MealCategoryRepository
		{
			get
			{
				if ( this.mealCategoryRepository == null )
					this.mealCategoryRepository = new GenericRepository<MealCategory>( this.context );
				return this.mealCategoryRepository;
			}
		}

		public IGenericRepository<MealProduct> MealProductRepository
		{
			get
			{
				if ( this.mealProductRepository == null )
					this.mealProductRepository = new GenericRepository<MealProduct>( this.context );
				return this.mealProductRepository;
			}
		}

		public IGenericRepository<Product> ProductRepository
		{
			get
			{
				if ( this.productRepository == null )
					this.productRepository = new GenericRepository<Product>( this.context );
				return this.productRepository;
			}
		}

		public IGenericRepository<ProductCategory> ProductCategoryRepository
		{
			get
			{
				if ( this.productCategoryRepository == null )
					this.productCategoryRepository = new GenericRepository<ProductCategory>( this.context );
				return this.productCategoryRepository;
			}
		}

		public IGenericRepository<Shop> ShopRepository
		{
			get
			{
				if ( this.shopRepository == null )
					this.shopRepository = new GenericRepository<Shop>( this.context );
				return this.shopRepository;
			}
		}

		public IGenericRepository<ShopProduct> ShopProductRepository
		{
			get
			{
				if ( this.shopProductRepository == null )
					this.shopProductRepository = new GenericRepository<ShopProduct>( this.context );
				return this.shopProductRepository;
			}
		}

		#endregion Repositories

		public void Commit()
		{
			try
			{
				this.context.SaveChanges();
			}
			catch ( DbEntityValidationException ex )
			{
				StringBuilder sb = new StringBuilder();

				foreach ( var failure in ex.EntityValidationErrors )
				{
					sb.AppendFormat( "{0} failed validation\n", failure.Entry.Entity.GetType() );
					foreach ( var error in failure.ValidationErrors )
					{
						sb.AppendFormat( "- {0} : {1}", error.PropertyName, error.ErrorMessage );
						sb.AppendLine();
					}
				}
				throw new Exception( string.Format( "DB Entity validation Exception: {0}", sb.ToString() ), ex );
			}
		}

		/// <summary>
		/// Discards all changes
		/// </summary>
		public void Rollback()
		{
			foreach ( DbEntityEntry entry in context.ChangeTracker.Entries() )
			{
				switch ( entry.State )
				{
					case EntityState.Modified:
						entry.State = EntityState.Unchanged;
						break;
					case EntityState.Added:
						entry.State = EntityState.Detached;
						break;
					case EntityState.Deleted:
						entry.Reload();
						break;
					default: break;
				}
			}
		}

		#endregion IUnitOfWork

		#region IDisposable

		private bool disposed = false;

		protected virtual void Dispose( bool disposing )
		{
			if ( !this.disposed )
			{
				if ( disposing )
				{
					if ( this.transaction != null )
					{
						this.transaction.Rollback();
						this.transaction.Dispose();
					}
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose( true );
			GC.SuppressFinalize( this );
		}

		#endregion IDisposable
	}
}

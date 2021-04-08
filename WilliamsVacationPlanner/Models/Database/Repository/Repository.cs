using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds functionality for a generic Entity DbSet.
	/// 
	/// Author: Nolan Williams
	/// Date:	4/3/2021
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="WilliamsSalesRep.Models.Database.Repositories.IRepository{T}" />
	public class Repository<T> : IRepository<T> where T : class
	{
		#region Members

		protected VacationPlannerContext context { get; set; }
		private DbSet<T> dbset { get; set; }

		private int? count;

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="Repository{T}"/> class.
		/// </summary>
		/// <param name="ctx">The CTX.</param>
		public Repository(VacationPlannerContext ctx)
		{
			context = ctx;
			dbset = context.Set<T>();
		}

		#endregion

		#region IRepository

		/// <summary>
		/// Gets the count.
		/// </summary>
		/// <value>
		/// The count.
		/// </value>
		public int Count => count ?? dbset.Count();

		/// <summary>
		/// Lists the specified options.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public virtual IEnumerable<T> List(QueryOptions<T> options)
		{
			IQueryable<T> query = BuildQuery(options);
			return query.ToList();
		}

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public virtual T Get(int id) => dbset.Find(id);

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public virtual T Get(string id) => dbset.Find(id);

		/// <summary>
		/// Gets the specified options.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public virtual T Get(QueryOptions<T> options)
		{
			IQueryable<T> query = BuildQuery(options);
			return query.FirstOrDefault();
		}

		/// <summary>
		/// Inserts the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public virtual void Insert(T entity) => dbset.Add(entity);

		/// <summary>
		/// Updates the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public virtual void Update(T entity) => dbset.Update(entity);

		/// <summary>
		/// Deletes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public virtual void Delete(T entity) => dbset.Remove(entity);

		/// <summary>
		/// Saves this instance.
		/// </summary>
		public virtual void Save() => context.SaveChanges();

		/// <summary>
		/// Builds the query.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		private IQueryable<T> BuildQuery(QueryOptions<T> options)
		{
			IQueryable<T> query = dbset;
			foreach (string include in options.GetIncludes())
			{
				query = query.Include(include);
			}
			if (options.HasWhere)
			{
				foreach (var clause in options.WhereClauses)
				{
					query = query.Where(clause);
				}
				count = query.Count();
			}
			if (options.HasOrderBy)
			{
				if (options.OrderByDirection == "asc")
					query = query.OrderBy(options.OrderBy);
				else
					query = query.OrderByDescending(options.OrderBy);
			}
			if (options.HasPaging)
				query = query.PageBy(options.PageNumber, options.PageSize);

			return query;
		}

		#endregion
	}
}

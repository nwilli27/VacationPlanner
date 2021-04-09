using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds functionality for accessing a DB.
	/// 
	/// Author: Nolan Williams
	/// Date:	4/3/2021
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T> where T : class
	{
		#region Methods

		/// <summary>
		/// Lists the specified options.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		IEnumerable<T> List(QueryOptions<T> options);

		/// <summary>
		/// Gets the count.
		/// </summary>
		/// <value>
		/// The count.
		/// </value>
		int Count { get; }

		/// <summary>
		/// Gets the specified options.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		T Get(QueryOptions<T> options);

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		T Get(int id);

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		T Get(string id);

		/// <summary>
		/// Detaches the tracking.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void DetachTracking(T entity);

		/// <summary>
		/// Inserts the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Insert(T entity);

		/// <summary>
		/// Updates the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Update(T entity);

		/// <summary>
		/// Deletes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Delete(T entity);

		/// <summary>
		/// Saves this instance.
		/// </summary>
		void Save();

		#endregion
	}
}

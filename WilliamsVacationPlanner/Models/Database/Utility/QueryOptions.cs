using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds functionality for a Query
	/// 
	/// Author: Nolan Williams
	/// Date:   4/7/2021
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class QueryOptions<T>
	{

		/// <summary>
		/// Gets or sets the order by.
		/// </summary>
		/// <value>
		/// The order by.
		/// </value>
		public Expression<Func<T, Object>> OrderBy { get; set; }

		/// <summary>
		/// Gets or sets the order by direction.
		/// </summary>
		/// <value>
		/// The order by direction.
		/// </value>
		public string OrderByDirection { get; set; } = "asc";

		/// <summary>
		/// Gets or sets the page number.
		/// </summary>
		/// <value>
		/// The page number.
		/// </value>
		public int PageNumber { get; set; }

		/// <summary>
		/// Gets or sets the size of the page.
		/// </summary>
		/// <value>
		/// The size of the page.
		/// </value>
		public int PageSize { get; set; }

		/// <summary>
		/// Gets or sets the where clauses.
		/// </summary>
		/// <value>
		/// The where clauses.
		/// </value>
		public WhereClauses<T> WhereClauses { get; set; }

		/// <summary>
		/// Sets the where.
		/// </summary>
		/// <value>
		/// The where.
		/// </value>
		public Expression<Func<T, bool>> Where
		{
			set
			{
				if (WhereClauses == null)
				{
					WhereClauses = new WhereClauses<T>();
				}
				WhereClauses.Add(value);
			}
		}

		private string[] includes;

		/// <summary>
		/// Sets the includes.
		/// </summary>
		/// <value>
		/// The includes.
		/// </value>
		public string Includes
		{
			set => includes = value.Replace(" ", "").Split(',');
		}

		/// <summary>
		/// Gets the includes.
		/// </summary>
		/// <returns></returns>
		public string[] GetIncludes() => includes ?? new string[0];

		/// <summary>
		/// Gets a value indicating whether this instance has where.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance has where; otherwise, <c>false</c>.
		/// </value>
		public bool HasWhere => WhereClauses != null;

		/// <summary>
		/// Gets a value indicating whether this instance has order by.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance has order by; otherwise, <c>false</c>.
		/// </value>
		public bool HasOrderBy => OrderBy != null;

		/// <summary>
		/// Gets a value indicating whether this instance has paging.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance has paging; otherwise, <c>false</c>.
		/// </value>
		public bool HasPaging => PageNumber > 0 && PageSize > 0;
	}

	/// <summary>
	/// Extends functionality from a list of generic expressions
	/// 
	/// Author: Nolan Williams
	/// Date:	4/3/2021
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="System.Collections.Generic.List{System.Linq.Expressions.Expression{System.Func{T, System.Boolean}}}" />
	public class WhereClauses<T> : List<Expression<Func<T, bool>>> { }
}

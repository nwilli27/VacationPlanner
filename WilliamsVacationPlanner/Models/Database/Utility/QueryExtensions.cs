using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds extension functionality for an IQueryable obj
	/// 
	/// Author: Nolan Williams
	/// Date:   4/7/2021
	/// </summary>
	public static class QueryExtensions
	{

		/// <summary>
		/// Returns the items based on the given [pagenumber] and [pagesize].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items">The items.</param>
		/// <param name="pagenumber">The pagenumber.</param>
		/// <param name="pagesize">The pagesize.</param>
		/// <returns>Set of items split based on the pagenumber and pagesize</returns>
		public static IQueryable<T> PageBy<T>(this IQueryable<T> items,
			int pagenumber, int pagesize)
		{
			return items
				.Skip((pagenumber - 1) * pagesize)
				.Take(pagesize);
		}
	}
}

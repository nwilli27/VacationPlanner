using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds functionality for format a Grid
	/// 
	/// Author: Nolan Williams
	/// Date:   4/7/2021
	/// </summary>
	public class GridBuilder
	{
		protected const string RouteKey = "currentroute";

		protected RouteDictionary routes { get; set; }
		protected ISession session { get; set; }

		/// <summary>
		/// Gets the current route.
		/// </summary>
		/// <value>
		/// The current route.
		/// </value>
		public RouteDictionary CurrentRoute => routes;

		/// <summary>
		/// Initializes a new instance of the <see cref="GridBuilder"/> class.
		/// </summary>
		/// <param name="sess">The sess.</param>
		public GridBuilder(ISession sess)
		{
			session = sess;
			routes = session.GetObject<RouteDictionary>(RouteKey) ?? new RouteDictionary();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GridBuilder"/> class.
		/// </summary>
		/// <param name="sess">The sess.</param>
		/// <param name="values">The values.</param>
		/// <param name="defaultSortField">The default sort field.</param>
		public GridBuilder(ISession sess, GridDTO values, string defaultSortField)
		{
			session = sess;

			routes = new RouteDictionary();
			routes.PageNumber = values.PageNumber;
			routes.PageSize = values.PageSize;
			routes.SortField = values.SortField ?? defaultSortField;
			routes.SortDirection = values.SortDirection;

			SaveRouteSegments();
		}

		/// <summary>
		/// Saves the route segments.
		/// </summary>
		public void SaveRouteSegments() =>
			session.SetObject<RouteDictionary>(RouteKey, routes);

		/// <summary>
		/// Gets the total pages.
		/// </summary>
		/// <param name="count">The count.</param>
		/// <returns></returns>
		public int GetTotalPages(int count)
		{
			int size = routes.PageSize;
			return (count + size - 1) / size;
		}
	}
}

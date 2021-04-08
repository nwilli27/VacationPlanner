using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds generic Grid ordering options
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	public class GridDTO
	{

		/// <summary>
		/// Gets or sets the page number.
		/// </summary>
		/// <value>
		/// The page number.
		/// </value>
		public int PageNumber { get; set; } = 1;

		/// <summary>
		/// Gets or sets the size of the page.
		/// </summary>
		/// <value>
		/// The size of the page.
		/// </value>
		public int PageSize { get; set; } = 3;

		/// <summary>
		/// Gets or sets the sort field.
		/// </summary>
		/// <value>
		/// The sort field.
		/// </value>
		public string SortField { get; set; }

		/// <summary>
		/// Gets or sets the sort direction.
		/// </summary>
		/// <value>
		/// The sort direction.
		/// </value>
		public string SortDirection { get; set; } = "asc";
	}
}

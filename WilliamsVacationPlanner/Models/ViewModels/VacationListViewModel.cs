using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds data needed for the VacationList view
	/// 
	/// Author: Nolan Williams
	/// Date:	4/8/2021
	/// </summary>
	public class VacationListViewModel
	{

		/// <summary>
		/// Gets or sets the vacations.
		/// </summary>
		/// <value>
		/// The vacations.
		/// </value>
		public IEnumerable<Vacation> Vacations { get; set; }

		/// <summary>
		/// Gets the page sizes.
		/// </summary>
		/// <value>
		/// The page sizes.
		/// </value>
		public int[] PageSizes => new int[] { 1, 2, 3, 4, 5 };

		/// <summary>
		/// Gets or sets the current route.
		/// </summary>
		/// <value>
		/// The current route.
		/// </value>
		public RouteDictionary CurrentRoute { get; set; }

		/// <summary>
		/// Gets or sets the total pages.
		/// </summary>
		/// <value>
		/// The total pages.
		/// </value>
		public int TotalPages { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds data for the Vacation step one view 
	/// 
	/// Author: Nolan Williams
	/// Date:	4/8/2021
	/// </summary>
	public class VacationStepOneViewModel
	{

		/// <summary>
		/// Gets or sets the vacation.
		/// </summary>
		/// <value>
		/// The vacation.
		/// </value>
		public Vacation Vacation { get; set; }

		/// <summary>
		/// Gets or sets the locations.
		/// </summary>
		/// <value>
		/// The locations.
		/// </value>
		public IEnumerable<Location> Locations { get; set; }

		/// <summary>
		/// Gets or sets the accommodations.
		/// </summary>
		/// <value>
		/// The accommodations.
		/// </value>
		public IEnumerable<Accommodation> Accommodations { get; set; }
	}
}

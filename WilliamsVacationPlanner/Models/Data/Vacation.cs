using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds data for a Vacation
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	public class Vacation
	{

		/// <summary>
		/// Gets or sets the vacation identifier.
		/// </summary>
		/// <value>
		/// The vacation identifier.
		/// </value>
		public int VacationId { get; set; }

		/// <summary>
		/// Gets or sets the location identifier.
		/// </summary>
		/// <value>
		/// The location identifier.
		/// </value>
		public int LocationId { get; set; }

		/// <summary>
		/// Gets or sets the location.
		/// </summary>
		/// <value>
		/// The location.
		/// </value>
		public Location Location { get; set; }

		/// <summary>
		/// Gets or sets the accommodation identifier.
		/// </summary>
		/// <value>
		/// The accommodation identifier.
		/// </value>
		public int? AccommodationId { get; set; }

		/// <summary>
		/// Gets or sets the accommodation.
		/// </summary>
		/// <value>
		/// The accommodation.
		/// </value>
		public Accommodation Accommodation { get; set; }

		/// <summary>
		/// Gets or sets the start date.
		/// </summary>
		/// <value>
		/// The start date.
		/// </value>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// Gets or sets the end date.
		/// </summary>
		/// <value>
		/// The end date.
		/// </value>
		public DateTime EndDate { get; set; }

		/// <summary>
		/// Gets or sets the activities.
		/// </summary>
		/// <value>
		/// The activities.
		/// </value>
		public ICollection<VacationActivity> Activities { get; set; }
	}
}

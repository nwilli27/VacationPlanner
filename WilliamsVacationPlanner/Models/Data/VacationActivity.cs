using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds data for a vacation activity
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	public class VacationActivity
	{

		/// <summary>
		/// Gets or sets the vacation identifier.
		/// </summary>
		/// <value>
		/// The vacation identifier.
		/// </value>
		public int VacationId { get; set; }

		/// <summary>
		/// Gets or sets the activity identifier.
		/// </summary>
		/// <value>
		/// The activity identifier.
		/// </value>
		public int ActivityId { get; set; }

		/// <summary>
		/// Gets or sets the vacation.
		/// </summary>
		/// <value>
		/// The vacation.
		/// </value>
		public Vacation Vacation { get; set; }

		/// <summary>
		/// Gets or sets the activity.
		/// </summary>
		/// <value>
		/// The activity.
		/// </value>
		public Activity Activity { get; set; }
	}
}

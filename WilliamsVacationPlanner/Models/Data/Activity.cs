using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds data for an Activity
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	public class Activity
	{

		/// <summary>
		/// Gets or sets the activity identifier.
		/// </summary>
		/// <value>
		/// The activity identifier.
		/// </value>
		public int ActivityId { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }
	}
}

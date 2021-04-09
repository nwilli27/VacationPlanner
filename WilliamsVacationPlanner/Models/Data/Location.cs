using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds data for a Location
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	public class Location
	{

		/// <summary>
		/// Gets or sets the location identifier.
		/// </summary>
		/// <value>
		/// The location identifier.
		/// </value>
		public int LocationId { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }
	}
}

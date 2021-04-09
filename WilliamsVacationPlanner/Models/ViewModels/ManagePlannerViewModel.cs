using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds data needed for the Manage planner view
	/// 
	/// Author: Nolan Williams
	/// Date:	4/8/2021
	/// </summary>
	public class ManagePlannerViewModel
	{

		/// <summary>
		/// Gets or sets the location to add.
		/// </summary>
		/// <value>
		/// The location to add.
		/// </value>
		public Location LocationToAdd { get; set; }

		/// <summary>
		/// Gets or sets the accommodation to add.
		/// </summary>
		/// <value>
		/// The accommodation to add.
		/// </value>
		public Accommodation AccommodationToAdd { get; set; }

		/// <summary>
		/// Gets or sets the activity to add.
		/// </summary>
		/// <value>
		/// The activity to add.
		/// </value>
		public Activity ActivityToAdd { get; set; }

		/// <summary>
		/// Gets or sets the location to delete.
		/// </summary>
		/// <value>
		/// The location to delete.
		/// </value>
		public Location LocationToDelete { get; set; }

		/// <summary>
		/// Gets or sets the accommodation to delete.
		/// </summary>
		/// <value>
		/// The accommodation to delete.
		/// </value>
		public Accommodation AccommodationToDelete { get; set; }

		/// <summary>
		/// Gets or sets the activity to delete.
		/// </summary>
		/// <value>
		/// The activity to delete.
		/// </value>
		public Activity ActivityToDelete { get; set; }

		/// <summary>
		/// Gets or sets the locations.
		/// </summary>
		/// <value>
		/// The locations.
		/// </value>
		public IEnumerable<Location> Locations { get; set; }

		/// <summary>
		/// Gets or sets the accomodations.
		/// </summary>
		/// <value>
		/// The accomodations.
		/// </value>
		public IEnumerable<Accommodation> Accomodations { get; set; }

		/// <summary>
		/// Gets or sets the activities.
		/// </summary>
		/// <value>
		/// The activities.
		/// </value>
		public IEnumerable<Activity> Activities { get; set; }
	}
}

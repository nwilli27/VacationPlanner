using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilliamsVacationPlanner.Models.Database.Repository;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds functionality for operations interacting with the database.
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	public interface IVacationPlannerDataAccessor
	{

		/// <summary>
		/// Gets the vacations.
		/// </summary>
		/// <value>
		/// The vacations.
		/// </value>
		IRepository<Vacation> Vacations { get; }

		/// <summary>
		/// Gets the accommodations.
		/// </summary>
		/// <value>
		/// The accommodations.
		/// </value>
		IRepository<Accommodation> Accommodations { get; }

		/// <summary>
		/// Gets the activities.
		/// </summary>
		/// <value>
		/// The activities.
		/// </value>
		IRepository<Activity> Activities { get; }

		/// <summary>
		/// Gets the locations.
		/// </summary>
		/// <value>
		/// The locations.
		/// </value>
		IRepository<Location> Locations { get; }

		/// <summary>
		/// Gets the vacation activities.
		/// </summary>
		/// <value>
		/// The vacation activities.
		/// </value>
		IRepository<VacationActivity> VacationActivities { get; }

		/// <summary>
		/// Saves this instance.
		/// </summary>
		void Save();
	}
}

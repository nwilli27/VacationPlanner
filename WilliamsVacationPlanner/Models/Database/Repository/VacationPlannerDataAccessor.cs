using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds the implementation for the IVacationPlannerDataAccessor
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	/// <seealso cref="WilliamsVacationPlanner.Models.IVacationPlannerDataAccessor" />
	public class VacationPlannerDataAccessor : IVacationPlannerDataAccessor
	{
		#region Members

		private VacationPlannerContext context { get; set; }

		private Repository<Vacation> vacations;
		private Repository<Accommodation> accommodations;
		private Repository<Activity> activities;
		private Repository<Location> locations;
		private Repository<VacationActivity> vacationActivities;

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="VacationPlannerDataAccessor"/> class.
		/// </summary>
		/// <param name="ctx">The CTX.</param>
		public VacationPlannerDataAccessor(VacationPlannerContext ctx) => context = ctx;

		#endregion

		#region IVacationPlannerDataAccessor

		/// <summary>
		/// Gets the vacations.
		/// </summary>
		/// <value>
		/// The vacations.
		/// </value>
		public IRepository<Vacation> Vacations
		{
			get
			{
				if (this.vacations == null) this.vacations = new Repository<Vacation>(context);
				return this.vacations;
			}
		}

		/// <summary>
		/// Gets the accommodations.
		/// </summary>
		/// <value>
		/// The accommodations.
		/// </value>
		public IRepository<Accommodation> Accommodations
		{
			get
			{
				if (this.accommodations == null) this.accommodations = new Repository<Accommodation>(context);
				return this.accommodations;
			}
		}

		/// <summary>
		/// Gets the activities.
		/// </summary>
		/// <value>
		/// The activities.
		/// </value>
		public IRepository<Activity> Activities
		{
			get
			{
				if (this.activities == null) this.activities = new Repository<Activity>(context);
				return this.activities;
			}
		}

		/// <summary>
		/// Gets the locations.
		/// </summary>
		/// <value>
		/// The locations.
		/// </value>
		public IRepository<Location> Locations
		{
			get
			{
				if (this.locations == null) this.locations = new Repository<Location>(context);
				return this.locations;
			}
		}

		/// <summary>
		/// Gets the vacation activities.
		/// </summary>
		/// <value>
		/// The vacation activities.
		/// </value>
		public IRepository<VacationActivity> VacationActivities
		{
			get
			{
				if (this.vacationActivities == null) this.vacationActivities = new Repository<VacationActivity>(context);
				return this.vacationActivities;
			}
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		public void Save() => context.SaveChanges();

		/// <summary>
		/// Adds the vacation activities.
		/// </summary>
		/// <param name="vacation">The vacation.</param>
		/// <param name="activityIds">The activity ids.</param>
		public void AddVacationActivities(Vacation vacation, int[] activityIds)
		{
			foreach (int id in activityIds)
			{
				var vacationActivity = new VacationActivity { VacationId = vacation.VacationId, ActivityId = id };
				VacationActivities.Insert(vacationActivity);
			}
		}

		#endregion
	}
}

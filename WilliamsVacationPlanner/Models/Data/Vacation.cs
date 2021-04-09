using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
	[VacationDateRange(ErrorMessage = "Please select a end date greater than or equal to the open date.")]
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
		[Range(1, Int32.MaxValue, ErrorMessage = "Please select a Location.")]
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
		[Range(1, Int32.MaxValue, ErrorMessage = "Please select a Accommodation.")]
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
		[DateStartToday(ErrorMessage = "Please select a date today or greater.")]
		public DateTime StartDate { get; set; } = DateTime.Today;

		/// <summary>
		/// Gets or sets the end date.
		/// </summary>
		/// <value>
		/// The end date.
		/// </value>
		[DateStartToday(ErrorMessage = "Please select a date today or greater.")]
		public DateTime EndDate { get; set; } = DateTime.Today.AddDays(1);

		/// <summary>
		/// Gets or sets the activities.
		/// </summary>
		/// <value>
		/// The activities.
		/// </value>
		public ICollection<VacationActivity> Activities { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds data needed for the Vacation step two view.
	/// 
	/// Author: Nolan Williams
	/// Date:	4/8/2021
	/// </summary>
	/// <seealso cref="System.ComponentModel.DataAnnotations.IValidatableObject" />
	public class VacationStepTwoViewModel : IValidatableObject
	{

		/// <summary>
		/// Gets or sets the vacation.
		/// </summary>
		/// <value>
		/// The vacation.
		/// </value>
		public Vacation Vacation { get; set; }

		/// <summary>
		/// Gets or sets the selected activities.
		/// </summary>
		/// <value>
		/// The selected activities.
		/// </value>
		public int[] SelectedActivities { get; set; }

		/// <summary>
		/// Gets or sets the activities.
		/// </summary>
		/// <value>
		/// The activities.
		/// </value>
		public IEnumerable<Activity> Activities { get; set; }

		/// <summary>
		/// Validates the specified CTX.
		/// </summary>
		/// <param name="ctx">The CTX.</param>
		/// <returns></returns>
		public IEnumerable<ValidationResult> Validate(ValidationContext ctx)
		{
			if (SelectedActivities == null)
			{
				yield return new ValidationResult(
				  "Please select at least one activity.",
				  new[] { nameof(SelectedActivities) });
			}
		}
	}
}

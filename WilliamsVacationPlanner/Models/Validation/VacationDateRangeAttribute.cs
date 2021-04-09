using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Custom validation for vacation start/end date
	/// 
	/// Author: Nolan Williams
	/// Date:	4/8/2021
	/// </summary>
	/// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
	public class VacationDateRangeAttribute : ValidationAttribute
	{
		/// <summary>
		/// Returns true if vacation end is greater than the start date; otherwise false.
		/// </summary>
		/// <param name="value">The value of the object to validate.</param>
		/// <returns>
		/// Returns true if the vacation end is greater than the start; otherwise false
		/// </returns>
		public override bool IsValid(object value)
		{
			var vacation = value as Vacation;

			if (vacation != null)
			{
				return vacation.EndDate >= vacation.StartDate;
			}

			return true;
		}
	}
}

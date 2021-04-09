using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Custom validation that validates the date starts today.
	/// 
	/// Author: Nolan Williams
	/// Date:	4/8/2021
	/// </summary>
	/// <seealso cref="System.ComponentModel.DataAnnotations.RangeAttribute" />
	public class DateStartTodayAttribute : RangeAttribute
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="DateStartTodayAttribute"/> class.
		/// </summary>
		public DateStartTodayAttribute() : base(typeof(DateTime), DateTime.Today.ToShortDateString(), DateTime.MaxValue.ToShortDateString()) { }
	}
}

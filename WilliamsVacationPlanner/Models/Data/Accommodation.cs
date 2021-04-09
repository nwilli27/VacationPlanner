using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds data for an Accommodation
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	public class Accommodation
	{

		/// <summary>
		/// Gets or sets the accommodation identifier.
		/// </summary>
		/// <value>
		/// The accommodation identifier.
		/// </value>
		public int AccommodationId { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the phone.
		/// </summary>
		/// <value>
		/// The phone.
		/// </value>
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone number format is not valid.")]
		public string Phone { get; set; }

		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>
		/// The email.
		/// </value>
		[EmailAddress(ErrorMessage = "Entered email format is not valid.")]
		public string Email { get; set; }
	}
}

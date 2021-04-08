using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds functionality to format a grid of Vacation
	/// 
	/// Author: Nolan Williams
	/// Date:   4/7/2021
	/// </summary>
	/// <seealso cref="WilliamsSalesRep.Models.GridBuilder" />
	public class VacationGridBuilder : GridBuilder
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="VacationGridBuilder"/> class.
		/// </summary>
		/// <param name="sess">The sess.</param>
		public VacationGridBuilder(ISession sess) : base(sess) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="VacationGridBuilder"/> class.
		/// </summary>
		/// <param name="sess">The sess.</param>
		/// <param name="values">The values.</param>
		/// <param name="defaultSortField">The default sort field.</param>
		public VacationGridBuilder(ISession sess, GridDTO values, string defaultSortField)
			: base(sess, values, defaultSortField)
		{
		}

		/// <summary>
		/// Gets a value indicating whether this instance is sort by location.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is sort by location; otherwise, <c>false</c>.
		/// </value>
		public bool IsSortByLocation => routes.SortField.EqualsNoCase(nameof(Vacation.Location.Name));

		/// <summary>
		/// Gets a value indicating whether this instance is sort by start date.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is sort by start date; otherwise, <c>false</c>.
		/// </value>
		public bool IsSortByStartDate => routes.SortField.EqualsNoCase(nameof(Vacation.StartDate));

		/// <summary>
		/// Gets a value indicating whether this instance is sort by end date.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is sort by end date; otherwise, <c>false</c>.
		/// </value>
		public bool IsSortByEndDate => routes.SortField.EqualsNoCase(nameof(Vacation.EndDate));

		/// <summary>
		/// Gets a value indicating whether this instance is sort by accommodation.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is sort by accommodation; otherwise, <c>false</c>.
		/// </value>
		public bool IsSortByAccommodation => routes.SortField.EqualsNoCase(nameof(Vacation.Accommodation.Name));

		/// <summary>
		/// Gets a value indicating whether this instance is sort by activities.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is sort by activities; otherwise, <c>false</c>.
		/// </value>
		public bool IsSortByActivities => routes.SortField.EqualsNoCase(nameof(Vacation.Activities));

	}
}

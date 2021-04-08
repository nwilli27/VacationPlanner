using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds functionality for a Nav
	/// 
	/// Author: Nolan Williams
	/// Date:   4/8/2021
	/// </summary>
	public static class Nav
	{

		/// <summary>
		/// Actives the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="current">The current.</param>
		/// <returns>active flag is current; otherwise empty string</returns>
		public static string Active(string value, string current) =>
			(value == current) ? "active" : "";

		/// <summary>
		/// Actives the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="current">The current.</param>
		/// <returns>active flag is current; otherwise empty string</returns>
		public static string Active(int value, int current) =>
			(value == current) ? "active" : "";
	}
}

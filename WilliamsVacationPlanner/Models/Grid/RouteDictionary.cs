using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds functionality for various Routes
	/// 
	/// Author: Nolan Williams
	/// Date:   4/7/2021
	/// </summary>
	/// <seealso cref="System.Collections.Generic.Dictionary{System.String, System.String}" />
	public class RouteDictionary : Dictionary<string, string>
	{

		/// <summary>
		/// Gets or sets the page number.
		/// </summary>
		/// <value>
		/// The page number.
		/// </value>
		public int PageNumber
		{
			get => Get(nameof(GridDTO.PageNumber)).ToInt();
			set => this[nameof(GridDTO.PageNumber)] = value.ToString();
		}

		/// <summary>
		/// Gets or sets the size of the page.
		/// </summary>
		/// <value>
		/// The size of the page.
		/// </value>
		public int PageSize
		{
			get => Get(nameof(GridDTO.PageSize)).ToInt();
			set => this[nameof(GridDTO.PageSize)] = value.ToString();
		}

		/// <summary>
		/// Gets or sets the sort field.
		/// </summary>
		/// <value>
		/// The sort field.
		/// </value>
		public string SortField
		{
			get => Get(nameof(GridDTO.SortField));
			set => this[nameof(GridDTO.SortField)] = value;
		}

		/// <summary>
		/// Gets or sets the sort direction.
		/// </summary>
		/// <value>
		/// The sort direction.
		/// </value>
		public string SortDirection
		{
			get => Get(nameof(GridDTO.SortDirection));
			set => this[nameof(GridDTO.SortDirection)] = value;
		}

		/// <summary>
		/// Sets the sort and direction.
		/// </summary>
		/// <param name="fieldName">Name of the field.</param>
		/// <param name="current">The current.</param>
		public void SetSortAndDirection(string fieldName, RouteDictionary current)
		{
			this[nameof(GridDTO.SortField)] = fieldName;

			if (current.SortField.EqualsNoCase(fieldName) &&
				current.SortDirection == "asc")
				this[nameof(GridDTO.SortDirection)] = "desc";
			else
				this[nameof(GridDTO.SortDirection)] = "asc";
		}

		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns></returns>
		public RouteDictionary Clone()
		{
			var clone = new RouteDictionary();
			foreach (var key in Keys)
			{
				clone.Add(key, this[key]);
			}
			return clone;
		}

		private string Get(string key) => Keys.Contains(key) ? this[key] : null;
	}
}

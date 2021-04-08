using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds extension methods for a string
	/// 
	/// Author: Nolan Williams
	/// Date:   4/7/2021
	/// </summary>
	public static class StringExtensions
	{

		/// <summary>
		/// Creates a formatted slug.
		/// </summary>
		/// <param name="s">The s.</param>
		/// <returns>A slug formatted from the string</returns>
		public static string Slug(this string s)
		{
			var sb = new StringBuilder();
			foreach (char c in s)
			{
				if (!char.IsPunctuation(c) || c == '-')
				{
					sb.Append(c);
				}
			}
			return sb.ToString().Replace(' ', '-').ToLower();
		}

		/// <summary>
		/// Returns true if strings are equal after being converted to lower case.
		/// </summary>
		/// <param name="s">The s.</param>
		/// <param name="tocompare">The tocompare.</param>
		/// <returns>True if equal; otherwise false</returns>
		public static bool EqualsNoCase(this string s, string tocompare) =>
			s?.ToLower() == tocompare?.ToLower();

		/// <summary>
		/// Converts the string representation of a number to an integer.
		/// </summary>
		/// <param name="s">The s.</param>
		/// <returns></returns>
		public static int ToInt(this string s)
		{
			int.TryParse(s, out int id);
			return id;
		}

		/// <summary>
		/// Capitalizes the specified string.
		/// </summary>
		/// <param name="s">The s.</param>
		/// <returns></returns>
		public static string Capitalize(this string s) =>
			s?.Substring(0, 1)?.ToUpper() + s?.Substring(1);
	}
}

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds extension methods for an ISession obj
	/// 
	/// Author: Nolan Williams
	/// Date:   4/7/2021
	/// </summary>
	public static class SessionExtensions
	{

		/// <summary>
		/// Allows you to set the generic [value] with the given [key] in the [session] obj.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="session">The session.</param>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public static void SetObject<T>(this ISession session, string key, T value) =>
			session.SetString(key, JsonConvert.SerializeObject(value));

		/// <summary>
		/// Returns the generic obj from the session with the given [key].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="session">The session.</param>
		/// <param name="key">The key.</param>
		/// <returns>Object from session with given [key].</returns>
		public static T GetObject<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			return value == null ? default : JsonConvert.DeserializeObject<T>(value);
		}
	}
}

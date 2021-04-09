using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Holds extension methods for a ITempDataDictionary obj
    /// 
    /// Author: Nolan Williams
    /// Date:   4/8/2021
	/// </summary>
	public static class TempDataExtensions
    {

		/// <summary>
		/// Serializes the specified [value] in the temp dictionary with the specified [key].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="tempData">The temporary data.</param>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

		/// <summary>
		/// Gets the specified key.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="tempData">The temporary data.</param>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }
}

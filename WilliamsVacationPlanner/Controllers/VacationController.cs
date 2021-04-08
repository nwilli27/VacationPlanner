using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilliamsVacationPlanner.Models;

namespace WilliamsVacationPlanner.Controllers
{
	/// <summary>
	/// Holds actions for the Vacation views
	/// 
	/// Author: Nolan Williams
	/// Date:	4/8/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class VacationController : Controller
	{

		private IVacationPlannerDataAccessor data { get; set; }
		private IHttpContextAccessor httpCtxAccessor { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="VacationController"/> class.
		/// </summary>
		/// <param name="dataAccessor">The data accessor.</param>
		/// <param name="httpCtx">The HTTP CTX.</param>
		public VacationController(IVacationPlannerDataAccessor dataAccessor, IHttpContextAccessor httpCtx)
		{
			this.data = dataAccessor;
			this.httpCtxAccessor = httpCtx;
		}

		/// <summary>
		/// Redirects to the List view action.
		/// </summary>
		/// <returns>Redirect to list view</returns>
		public IActionResult Index() => RedirectToAction("List");

		/// <summary>
		/// The List view action handling filtering/sorting for the list.
		/// </summary>
		/// <param name="values">The values.</param>
		/// <returns>The List view</returns>
		public IActionResult List(GridDTO values)
		{
			var builder = new VacationGridBuilder(this.httpCtxAccessor.HttpContext.Session, values, nameof(Vacation.Location.Name));

			var options = new VacationQueryOptions()
			{
				Includes = "Location, Activities.Activity, Accommodation",
				OrderByDirection = builder.CurrentRoute.SortDirection,
				PageNumber = builder.CurrentRoute.PageNumber,
				PageSize = builder.CurrentRoute.PageSize
			};
			
			options.Sort(builder);

			var vacationViewModel = new VacationListViewModel()
			{
				Vacations = data.Vacations.List(options),
				CurrentRoute = builder.CurrentRoute,
				TotalPages = builder.GetTotalPages(data.Vacations.Count)
			};

			return View(vacationViewModel);
		}

		/// <summary>
		/// PageSize post action method. Sets the route directory PageSize
		/// with the given [pagesize] and redirects to the List action.
		/// </summary>
		/// <param name="pagesize">The pagesize.</param>
		/// <returns>Redirect to List action.</returns>
		[HttpPost]
		public RedirectToActionResult PageSize(int pagesize)
		{
			var builder = new VacationGridBuilder(this.httpCtxAccessor.HttpContext.Session);

			builder.CurrentRoute.PageSize = pagesize;

			builder.SaveRouteSegments();
			return RedirectToAction("List", builder.CurrentRoute);
		}
	}
}

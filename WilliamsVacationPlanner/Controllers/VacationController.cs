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
		public IActionResult PageSize(int pagesize)
		{
			var builder = new VacationGridBuilder(this.httpCtxAccessor.HttpContext.Session);

			builder.CurrentRoute.PageSize = pagesize;

			builder.SaveRouteSegments();
			return RedirectToAction("List", builder.CurrentRoute);
		}

		/// <summary>
		/// Step one action. Returns StepOne view.
		/// </summary>
		/// <returns>Step one view.</returns>
		public IActionResult StepOne()
		{
			var viewModel = new VacationStepOneViewModel()
			{
				Vacation = new Vacation(),
				Locations = data.Locations.List(new QueryOptions<Location>() { OrderBy = l => l.Name }),
				Accommodations = data.Accommodations.List(new QueryOptions<Accommodation>() { OrderBy = a => a.Name })
			};

			return View(viewModel);
		}

		/// <summary>
		/// Step one post action, if valid moves to step two view.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		/// <returns>Step two if valid; otherwise itself</returns>
		[HttpPost]
		public IActionResult StepOne(VacationStepOneViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				viewModel.Vacation.Location = data.Locations.Get(new QueryOptions<Location>() { Where = l => l.LocationId == viewModel.Vacation.LocationId });
				TempData.Put("Vacation", viewModel.Vacation);

				return RedirectToAction("StepTwo");
			}
			else
			{
				var stepOneViewModel = new VacationStepOneViewModel()
				{
					Vacation = viewModel.Vacation,
					Locations = data.Locations.List(new QueryOptions<Location>() { OrderBy = l => l.Name }),
					Accommodations = data.Accommodations.List(new QueryOptions<Accommodation>() { OrderBy = a => a.Name })
				};

				return View(stepOneViewModel);
			}
		}

		/// <summary>
		/// Step two action. Returns Steptwo view.
		/// </summary>
		/// <returns>Step two view.</returns>
		public IActionResult StepTwo()
		{
			var vacation = TempData.Get<Vacation>("Vacation");

			if (vacation == null)
			{
				return RedirectToAction("List");
			}
			else
			{
				var viewModel = new VacationStepTwoViewModel()
				{
					Vacation = vacation,
					Activities = data.Activities.List(new QueryOptions<Activity>() { OrderBy = a => a.Name })
				};

				return View(viewModel);
			}
		}

		/// <summary>
		/// Step two post action. If valid adds vacation to DB and directs back to list,
		/// otherwise direct back to itself.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		/// <returns>Directs to list view if valid; otherwise to itself</returns>
		[HttpPost]
		public IActionResult StepTwo(VacationStepTwoViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				data.Vacations.Insert(viewModel.Vacation);
				data.Save();

				data.AddVacationActivities(viewModel.Vacation, viewModel.SelectedActivities);
				data.Save();

				return RedirectToAction("List");
			}
			else
			{
				viewModel.Vacation.Location = data.Locations.Get(new QueryOptions<Location>() { Where = l => l.LocationId == viewModel.Vacation.LocationId });
				var stepTwoViewModel = new VacationStepTwoViewModel()
				{
					Vacation = viewModel.Vacation,
					Activities = data.Activities.List(new QueryOptions<Activity>() { OrderBy = a => a.Name }),
					SelectedActivities = viewModel.Vacation.Activities?.Select(a => a.Activity.ActivityId).ToArray()
				};

				return View(stepTwoViewModel);
			}
		}
	}
}

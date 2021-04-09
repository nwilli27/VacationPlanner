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
		/// Returns the Delete confirmation view.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>The delete confirmation view</returns>
		public IActionResult Delete(int id)
		{
			var vacation = this.data.Vacations.Get(
				new QueryOptions<Vacation>() 
				{ 
					Includes = "Location", 
					Where = v => v.VacationId == id
				});
			return View(vacation);
		}

		/// <summary>
		/// Deletes the specified vacation.
		/// </summary>
		/// <param name="vacation">The vacation.</param>
		/// <returns>Redirect to list view.</returns>
		[HttpPost]
		public IActionResult Delete(Vacation vacation)
		{
			this.addConfirmationMessage($"Successfully deleted vacation at {vacation.Location.Name} on {vacation.StartDate.ToShortDateString()} thru {vacation.EndDate.ToShortDateString()}.");

			vacation.Location = null;
			this.data.Vacations.Delete(vacation);
			this.data.Save();
			
			return RedirectToAction("List");
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
				viewModel.Vacation.Location = data.Locations.Get(viewModel.Vacation.LocationId);
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
		/// Redirects back to List view with error message.
		/// </summary>
		/// <returns>Redirect back to List view</returns>
		public IActionResult CancelAddVacation()
		{
			this.addErrorMessage("You cancelled the progress of adding a new vacation.");
			return RedirectToAction("List");
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
				this.addErrorMessage("Refreshing cancelled the progress of adding a new vacation.");
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

				var location = data.Locations.Get(viewModel.Vacation.LocationId);
				this.addConfirmationMessage($"Successfully added new vacation at {location.Name} on {viewModel.Vacation.StartDate.ToShortDateString()} thru {viewModel.Vacation.EndDate.ToShortDateString()}.");

				return RedirectToAction("List");
			}
			else
			{
				viewModel.Vacation.Location = data.Locations.Get(viewModel.Vacation.LocationId);
				var stepTwoViewModel = new VacationStepTwoViewModel()
				{
					Vacation = viewModel.Vacation,
					Activities = data.Activities.List(new QueryOptions<Activity>() { OrderBy = a => a.Name }),
					SelectedActivities = viewModel.Vacation.Activities?.Select(a => a.Activity.ActivityId).ToArray()
				};

				return View(stepTwoViewModel);
			}
		}

		private void addConfirmationMessage(string message)
		{
			TempData["ConfirmationMessage"] = message;
		}

		private void addErrorMessage(string message)
		{
			TempData["ErrorMessage"] = message;
		}
	}
}

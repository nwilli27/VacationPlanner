using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilliamsVacationPlanner.Models;

namespace WilliamsVacationPlanner.Controllers
{
	/// <summary>
	/// Holds actions for the Manage views
	/// 
	/// Author: Nolan Williams
	/// Date:	4/8/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class ManageController : Controller
	{
		private IVacationPlannerDataAccessor data { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ManageController"/> class.
		/// </summary>
		/// <param name="dataAccessor">The data accessor.</param>
		/// <param name="httpCtx">The HTTP CTX.</param>
		public ManageController(IVacationPlannerDataAccessor dataAccessor)
		{
			this.data = dataAccessor;
		}

		/// <summary>
		/// Redirects to the Manage view.
		/// </summary>
		/// <returns>Redirect to manage view.</returns>
		public IActionResult Index() => RedirectToAction("Manage");

		/// <summary>
		/// Manages this instance.
		/// </summary>
		/// <returns></returns>
		public IActionResult Manage()
		{
			var viewModel = new ManagePlannerViewModel()
			{
				LocationToAdd = new Location(),
				AccommodationToAdd = new Accommodation(),
				ActivityToAdd = new Activity(),
				LocationToDelete = new Location(),
				AccommodationToDelete = new Accommodation(),
				ActivityToDelete = new Activity(),
				Locations = data.Locations.List(new QueryOptions<Location>() { OrderBy = l => l.Name }),
				Accomodations = data.Accommodations.List(new QueryOptions<Accommodation>() { OrderBy = a => a.Name }),
				Activities = data.Activities.List(new QueryOptions<Activity>() { OrderBy = a => a.Name })
			};

			return View(viewModel);
		}
	}
}

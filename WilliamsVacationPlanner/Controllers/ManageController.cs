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

		#region Actions

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
			return View(this.createManagePlannerViewModel(null));
		}

		/// <summary>
		/// Checks and adds the specified data from the [viewModel].
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		/// <returns>Redirect to Vacation list view; otherwise itself</returns>
		[HttpPost]
		public IActionResult Add(ManagePlannerViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var editingCount = this.getAddingCount(viewModel);

				if (editingCount > 1)
				{
					TempData["ErrorMessage"] = "You can only add one item at a time.";
					return View("Manage", this.createManagePlannerViewModel(viewModel));
				}
				else if (this.isMissingAccommodationName(viewModel.AccommodationToAdd))
				{
					var propertyKey = nameof(viewModel.AccommodationToAdd);
					var accommodationName = nameof(viewModel.AccommodationToAdd.Name);
					ModelState.AddModelError($"{propertyKey}.{accommodationName}", "Please enter a name.");
					return View("Manage", this.createManagePlannerViewModel(viewModel));
				}
				else if (editingCount == 0)
				{
					TempData["ErrorMessage"] = "You haven't added anything.";
					return View("Manage", this.createManagePlannerViewModel(viewModel));
				}

				this.addAndCreateMessage(viewModel);

				return RedirectToAction("List", "Vacation");
			}
			else
			{
				return View("Manage", this.createManagePlannerViewModel(viewModel));
			}
		}

		/// <summary>
		/// Checks and deletes the specified data from the [viewModel].
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		/// <returns>Redirect to Vacation list view; otherwise itself</returns>
		[HttpPost]
		public IActionResult Delete(ManagePlannerViewModel viewModel)
		{
			var deletingCount = this.getDeletingCount(viewModel);

			if (deletingCount > 1)
			{
				TempData["ErrorMessage"] = "You can only delete one item at a time.";
				return RedirectToAction("Manage");
			}
			else if (deletingCount == 0)
			{
				TempData["ErrorMessage"] = "You haven't selected anything to delete.";
				return View("Manage", this.createManagePlannerViewModel(viewModel));
			}

			this.deleteAndCreateMessage(viewModel);

			return RedirectToAction("List", "Vacation");
		}

		#endregion

		#region Private Helpers

		#region Add

		private void addAndCreateMessage(ManagePlannerViewModel viewModel)
		{
			try
			{
				var isAddingAccommodation = !string.IsNullOrEmpty(viewModel.AccommodationToAdd.Name);
				var isAddingActivity = !string.IsNullOrEmpty(viewModel.ActivityToAdd.Name);
				var isAddingLocation = !string.IsNullOrEmpty(viewModel.LocationToAdd.Name);

				if (isAddingAccommodation)
				{
					this.addAccommodation(viewModel.AccommodationToAdd);
				}
				else if (isAddingActivity)
				{
					this.addActivity(viewModel.ActivityToAdd);
				}
				else if (isAddingLocation)
				{
					this.addLocation(viewModel.LocationToAdd);
				}
			}
			catch (Exception err)
			{
				this.addErrorMessage(err.Message);
			}
		}

		private void addLocation(Location locationToAdd)
		{
			this.data.Locations.Insert(locationToAdd);
			this.data.Save();
			this.addConfirmationMessage($"Successfully added location {locationToAdd.Name}.");
		}

		private void addActivity(Activity activityToAdd)
		{
			this.data.Activities.Insert(activityToAdd);
			this.data.Save();
			this.addConfirmationMessage($"Successfully added activity {activityToAdd.Name}.");
		}

		private void addAccommodation(Accommodation accommodationToAdd)
		{
			this.data.Accommodations.Insert(accommodationToAdd);
			this.data.Save();
			this.addConfirmationMessage($"Successfully added accommodation {accommodationToAdd.Name}.");
		}

		private int getAddingCount(ManagePlannerViewModel viewModel)
		{
			var totalEditing = 0;

			totalEditing += string.IsNullOrEmpty(viewModel.AccommodationToAdd.Name) == true ? 0 : 1;
			totalEditing += string.IsNullOrEmpty(viewModel.ActivityToAdd.Name) == true ? 0 : 1;
			totalEditing += string.IsNullOrEmpty(viewModel.LocationToAdd.Name) == true ? 0 : 1;

			return totalEditing;
		}

		#endregion

		#region Delete

		private void deleteAndCreateMessage(ManagePlannerViewModel viewModel)
		{
			try
			{
				var isDeletingAccommodation = viewModel.AccommodationToDelete?.AccommodationId > 0;
				var isDeletingActivity = viewModel.ActivityToDelete?.ActivityId > 0;
				var isDeletingLocation = viewModel.LocationToDelete?.LocationId > 0;

				if (isDeletingAccommodation)
				{
					this.deleteAccommodation(viewModel.AccommodationToDelete);
				}
				else if (isDeletingActivity)
				{
					deleteActivity(viewModel.ActivityToDelete);
				}
				else if (isDeletingLocation)
				{
					deleteLocation(viewModel.LocationToDelete);
				}
			}
			catch (Exception err)
			{
				this.addErrorMessage(err.Message);
			}
		}

		private void deleteLocation(Location locationToDelete)
		{
			var linkedVacations = this.data.Vacations.List(new QueryOptions<Vacation>() { Where = v => v.LocationId == locationToDelete.LocationId }).ToList();
			var location = this.data.Locations.Get(locationToDelete.LocationId);
			this.data.Locations.DetachTracking(location);

			if (linkedVacations.Count > 0)
			{
				this.addErrorMessage($"Can't delete location {location.Name} because it is linked to {linkedVacations.Count} vacations.");
			}
			else
			{
				this.data.Locations.Delete(locationToDelete);
				this.data.Save();
				this.addConfirmationMessage($"Successfully deleted location {location.Name}.");
			}
		}

		private void deleteActivity(Activity activityToDelete)
		{
			var activity = this.data.Activities.Get(activityToDelete.ActivityId);
			this.data.Activities.DetachTracking(activity);
			this.data.Activities.Delete(activityToDelete);
			this.data.Save();
			this.addConfirmationMessage($"Successfully deleted activity {activity.Name}.");
		}

		private void deleteAccommodation(Accommodation accommodationToDelete)
		{
			var accommodation = this.data.Accommodations.Get(accommodationToDelete.AccommodationId);
			this.data.Accommodations.DetachTracking(accommodation);
			this.data.Accommodations.Delete(accommodationToDelete);
			this.data.Save();
			this.addConfirmationMessage($"Successfully deleted accommodation {accommodation.Name}.");
		}

		private int getDeletingCount(ManagePlannerViewModel viewModel)
		{
			var totalDeleting = 0;

			totalDeleting += viewModel.AccommodationToDelete.AccommodationId > 0 ? 1 : 0;
			totalDeleting += viewModel.ActivityToDelete.ActivityId > 0 ? 1 : 0;
			totalDeleting += viewModel.LocationToDelete.LocationId > 0 ? 1 : 0;

			return totalDeleting;
		}

		#endregion

		#region Other

		private ManagePlannerViewModel createManagePlannerViewModel(ManagePlannerViewModel prevViewModel)
		{
			if (prevViewModel == null)
			{
				return new ManagePlannerViewModel()
				{
					AccommodationToAdd = new Accommodation(),
					ActivityToAdd = new Activity(),
					LocationToDelete = new Location(),
					AccommodationToDelete = new Accommodation(),
					ActivityToDelete = new Activity(),
					Locations = data.Locations.List(new QueryOptions<Location>() { OrderBy = l => l.Name }),
					Accomodations = data.Accommodations.List(new QueryOptions<Accommodation>() { OrderBy = a => a.Name }),
					Activities = data.Activities.List(new QueryOptions<Activity>() { OrderBy = a => a.Name })
				};
			}
			else
			{
				return new ManagePlannerViewModel()
				{
					AccommodationToAdd = prevViewModel.AccommodationToAdd,
					ActivityToAdd = prevViewModel.ActivityToAdd,
					LocationToDelete = prevViewModel.LocationToDelete,
					AccommodationToDelete = prevViewModel.AccommodationToDelete,
					ActivityToDelete = prevViewModel.ActivityToDelete,
					Locations = data.Locations.List(new QueryOptions<Location>() { OrderBy = l => l.Name }),
					Accomodations = data.Accommodations.List(new QueryOptions<Accommodation>() { OrderBy = a => a.Name }),
					Activities = data.Activities.List(new QueryOptions<Activity>() { OrderBy = a => a.Name })
				};
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

		private bool isMissingAccommodationName(Accommodation accommodationToAdd)
		{
			var isPhoneAdded = !string.IsNullOrEmpty(accommodationToAdd.Phone);
			var isEmailAdded = !string.IsNullOrEmpty(accommodationToAdd.Email);
			var isNameAdded = !string.IsNullOrEmpty(accommodationToAdd.Name);

			return (isPhoneAdded || isEmailAdded) && !isNameAdded;
		}

		#endregion

		#endregion
	}
}

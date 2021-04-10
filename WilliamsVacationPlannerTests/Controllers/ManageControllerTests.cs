using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WilliamsVacationPlanner.Controllers;
using WilliamsVacationPlanner.Models;
using Xunit;

namespace WilliamsVacationPlannerTests.Controllers
{
	public class ManageControllerTests
	{
		[Fact]
		public void IndexAction_ReturnsRedirectToAction()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);

			var controller = new ManageController(mockDataAccessor.Object);
			var result = controller.Index();

			Assert.IsType<RedirectToActionResult>(result);
		}

		[Fact]
		public void ManageAction_ReturnsViewResult()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);

			var controller = new ManageController(mockDataAccessor.Object);
			var result = controller.Manage();

			Assert.IsType<ViewResult>(result);
		}

		[Fact]
		public void AddPostAction_ReturnsRedirectToAction()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);

			var controller = new ManageController(mockDataAccessor.Object) 
			{ 
				TempData = tempData
			};
			var result = controller.Add(new ManagePlannerViewModel()
			{
				AccommodationToAdd = new Accommodation(),
				ActivityToAdd = new Activity(),
				LocationToAdd = new Location(),
				LocationToDelete = new Location(),
				AccommodationToDelete = new Accommodation(),
				ActivityToDelete = new Activity(),
				Locations = new List<Location>(),
				Accomodations = new List<Accommodation>(),
				Activities = new List<Activity>()
			});

			Assert.IsType<ViewResult>(result);
		}

		[Fact]
		public void DeletePostAction_ReturnsRedirectToAction()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);

			var controller = new ManageController(mockDataAccessor.Object)
			{
				TempData = tempData
			};
			var result = controller.Delete(new ManagePlannerViewModel()
			{
				AccommodationToAdd = new Accommodation(),
				ActivityToAdd = new Activity(),
				LocationToAdd = new Location(),
				LocationToDelete = new Location(),
				AccommodationToDelete = new Accommodation(),
				ActivityToDelete = new Activity(),
				Locations = new List<Location>(),
				Accomodations = new List<Accommodation>(),
				Activities = new List<Activity>()
			});

			Assert.IsType<ViewResult>(result);
		}
	}
}

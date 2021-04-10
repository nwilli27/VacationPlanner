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
	public class VacationControllerTests
	{
		[Fact]
		public void IndexAction_ReturnsRedirectToAction()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
			var httpCtx = new Mock<IHttpContextAccessor>();

			var controller = new VacationController(mockDataAccessor.Object, httpCtx.Object) { TempData = tempData };
			var result = controller.Index();

			Assert.IsType<RedirectToActionResult>(result);
		}

		[Fact]
		public void ListAction_ReturnsViewResult()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
			var httpCtx = new Mock<IHttpContextAccessor>();
			httpCtx.Setup(m => m.HttpContext.Session).Returns(new Mock<ISession>().Object);

			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);
			mockDataAccessor.Setup(m => m.Vacations).Returns(new Mock<IRepository<Vacation>>().Object);

			var controller = new VacationController(mockDataAccessor.Object, httpCtx.Object) { TempData = tempData };
			var result = controller.List(new GridDTO());

			Assert.IsType<ViewResult>(result);
		}

		[Fact]
		public void PageSizeAction_ReturnsRedirectToAction()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
			var httpCtx = new Mock<IHttpContextAccessor>();
			httpCtx.Setup(m => m.HttpContext.Session).Returns(new Mock<ISession>().Object);

			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);
			mockDataAccessor.Setup(m => m.Vacations).Returns(new Mock<IRepository<Vacation>>().Object);

			var controller = new VacationController(mockDataAccessor.Object, httpCtx.Object) { TempData = tempData };
			var result = controller.PageSize(1);

			Assert.IsType<RedirectToActionResult>(result);
		}

		[Fact]
		public void DeleteAction_ReturnsViewResult()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
			var httpCtx = new Mock<IHttpContextAccessor>();

			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);
			mockDataAccessor.Setup(m => m.Vacations).Returns(new Mock<IRepository<Vacation>>().Object);

			var controller = new VacationController(mockDataAccessor.Object, httpCtx.Object) { TempData = tempData };
			var result = controller.Delete(1);

			Assert.IsType<ViewResult>(result);
		}

		[Fact]
		public void DeletePostAction_ReturnsRedirectToAction()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
			var httpCtx = new Mock<IHttpContextAccessor>();

			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);
			mockDataAccessor.Setup(m => m.Vacations).Returns(new Mock<IRepository<Vacation>>().Object);

			var controller = new VacationController(mockDataAccessor.Object, httpCtx.Object) { TempData = tempData };
			var result = controller.Delete(new Vacation() { Location = new Location() });

			Assert.IsType<RedirectToActionResult>(result);
		}

		[Fact]
		public void StepOneAction_ReturnsViewResult()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
			var httpCtx = new Mock<IHttpContextAccessor>();

			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);
			mockDataAccessor.Setup(m => m.Vacations).Returns(new Mock<IRepository<Vacation>>().Object);

			var controller = new VacationController(mockDataAccessor.Object, httpCtx.Object) { TempData = tempData };
			var result = controller.StepOne();

			Assert.IsType<ViewResult>(result);
		}

		[Fact]
		public void StepOnePostAction_ReturnsRedirectToAction()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
			var httpCtx = new Mock<IHttpContextAccessor>();

			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);
			mockDataAccessor.Setup(m => m.Vacations).Returns(new Mock<IRepository<Vacation>>().Object);

			var controller = new VacationController(mockDataAccessor.Object, httpCtx.Object) { TempData = tempData };
			var result = controller.StepOne(new VacationStepOneViewModel()
			{
				Vacation = new Vacation() { Location = new Location() },
				Locations = new List<Location>(),
				Accommodations = new List<Accommodation>()
			});

			Assert.IsType<RedirectToActionResult>(result);
		}


		[Fact]
		public void StepTwoAction_ReturnsRedirectToAction()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
			var httpCtx = new Mock<IHttpContextAccessor>();

			var controller = new VacationController(mockDataAccessor.Object, httpCtx.Object) { TempData = tempData };
			var result = controller.StepTwo();

			Assert.IsType<RedirectToActionResult>(result);
		}

		[Fact]
		public void StepTwoPostAction_ReturnsRedirectToAction()
		{
			var mockDataAccessor = new Mock<IVacationPlannerDataAccessor>();
			var httpContext = new DefaultHttpContext();
			var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
			var httpCtx = new Mock<IHttpContextAccessor>();

			mockDataAccessor.Setup(m => m.Locations).Returns(new Mock<IRepository<Location>>().Object);
			mockDataAccessor.Setup(m => m.Accommodations).Returns(new Mock<IRepository<Accommodation>>().Object);
			mockDataAccessor.Setup(m => m.Activities).Returns(new Mock<IRepository<Activity>>().Object);
			mockDataAccessor.Setup(m => m.Vacations).Returns(new Mock<IRepository<Vacation>>().Object);
			mockDataAccessor.Setup(m => m.Locations.Get(It.IsAny<int>())).Returns(new Location());

			var controller = new VacationController(mockDataAccessor.Object, httpCtx.Object) { TempData = tempData };
			var result = controller.StepTwo(new VacationStepTwoViewModel()
			{
				Vacation = new Vacation() { Location = new Location() },
				Activities = new List<Activity>() 
			});

			Assert.IsType<RedirectToActionResult>(result);
		}
	}
}

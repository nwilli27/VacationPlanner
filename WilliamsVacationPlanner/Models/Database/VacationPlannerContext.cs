using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	public class VacationPlannerContext : DbContext
	{
		#region Methods

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}

		#endregion
	}
}

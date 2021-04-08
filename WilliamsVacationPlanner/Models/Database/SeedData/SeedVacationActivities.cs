using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Seeds vacation activity data into DB
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{WilliamsVacationPlanner.Models.VacationActivity}" />
	public class SeedVacationActivities : IEntityTypeConfiguration<VacationActivity>
	{

		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<VacationActivity> builder)
		{
			builder.HasData(
				new VacationActivity() { ActivityId = 3, VacationId = 1 },
				new VacationActivity() { ActivityId = 1, VacationId = 1 },
				new VacationActivity() { ActivityId = 2, VacationId = 2 },
				new VacationActivity() { ActivityId = 4, VacationId = 2 },
				new VacationActivity() { ActivityId = 1, VacationId = 2 }
				);
		}
	}
}

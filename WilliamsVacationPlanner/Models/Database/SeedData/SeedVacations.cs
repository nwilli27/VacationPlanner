using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Seeds vacation data into DB
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{WilliamsVacationPlanner.Models.Vacation}" />
	public class SeedVacations : IEntityTypeConfiguration<Vacation>
	{

		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<Vacation> builder)
		{
			builder.HasData(
				new Vacation()
				{
					VacationId = 1,
					LocationId = 1,
					AccommodationId = 2,
					StartDate = DateTime.Today.AddDays(2),
					EndDate = DateTime.Today.AddDays(4)
				},
				new Vacation()
				{
					VacationId = 2,
					LocationId = 2,
					AccommodationId = 3,
					StartDate = DateTime.Today.AddDays(6),
					EndDate = DateTime.Today.AddDays(10)
				});
		}
	}
}

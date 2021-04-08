using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Seeds accommodation data into DB
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{WilliamsVacationPlanner.Models.Accommodation}" />
	public class SeedAccommodations : IEntityTypeConfiguration<Accommodation>
	{

		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<Accommodation> builder)
		{
			builder.HasData(
				new Accommodation()
				{
					AccommodationId = 1,
					Name = "Holiday Inn Express",
					Phone = "770-123-4567",
					Email = "holidayinn@gmail.com"
				},
				new Accommodation()
				{
					AccommodationId = 2,
					Name = "Hogwarts",
					Phone = "523-324-2342",
					Email = "hogwarts@gmail.com"
				},
				new Accommodation()
				{
					AccommodationId = 3,
					Name = "Bill's House",
					Phone = "451-532-5678",
					Email = "bill@gmail.com"
				});
		}
	}
}

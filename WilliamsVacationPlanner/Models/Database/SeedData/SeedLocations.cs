using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Seeds location data into DB
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{WilliamsVacationPlanner.Models.Location}" />
	public class SeedLocations : IEntityTypeConfiguration<Location>
	{

		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<Location> builder)
		{
			builder.HasData(
				new Location()
				{
					LocationId = 1,
					Name = "Disney Land"
				},
				new Location()
				{
					LocationId = 2,
					Name = "Lego Land"
				});
		}
	}
}

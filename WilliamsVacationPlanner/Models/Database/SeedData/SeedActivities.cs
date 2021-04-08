using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Seeds activity data into DB
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{WilliamsVacationPlanner.Models.Activity}" />
	public class SeedActivities : IEntityTypeConfiguration<Activity>
	{

		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<Activity> builder)
		{
			builder.HasData(
				new Activity()
				{
					ActivityId = 1,
					Name = "Hiking"
				},
				new Activity()
				{
					ActivityId = 2,
					Name = "Bowling"
				},
				new Activity()
				{
					ActivityId = 3,
					Name = "Gambling"
				},
				new Activity()
				{
					ActivityId = 4,
					Name = "Drinking"
				});
		}
	}
}

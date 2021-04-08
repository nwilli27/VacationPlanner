using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
	/// <summary>
	/// Establishes the DB schema for the VacationPlanner application
	/// 
	/// Author: Nolan Williams
	/// Date:	4/7/2021
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public class VacationPlannerContext : DbContext
	{
		#region Properties

		/// <summary>
		/// Gets or sets the vacations.
		/// </summary>
		/// <value>
		/// The vacations.
		/// </value>
		public DbSet<Vacation> Vacations { get; set; }

		/// <summary>
		/// Gets or sets the vacation activites.
		/// </summary>
		/// <value>
		/// The vacation activites.
		/// </value>
		public DbSet<VacationActivity> VacationActivites { get; set; }

		/// <summary>
		/// Gets or sets the accommodations.
		/// </summary>
		/// <value>
		/// The accommodations.
		/// </value>
		public DbSet<Accommodation> Accommodations { get; set; }

		/// <summary>
		/// Gets or sets the locations.
		/// </summary>
		/// <value>
		/// The locations.
		/// </value>
		public DbSet<Location> Locations { get; set; }

		/// <summary>
		/// Gets or sets the activities.
		/// </summary>
		/// <value>
		/// The activities.
		/// </value>
		public DbSet<Activity> Activities { get; set; }

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="VacationPlannerContext"/> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public VacationPlannerContext(DbContextOptions<VacationPlannerContext> options)
			: base(options)
		{ }

		#endregion

		#region Methods

		protected override void OnModelCreating(ModelBuilder builder)
		{
			this.buildKeys(builder);
			this.buildForeignKeys(builder);
			this.buildConstaints(builder);
			this.seedData(builder);
		}

		private void buildKeys(ModelBuilder builder)
		{
			builder.Entity<VacationActivity>().HasKey(va => new { va.VacationId, va.ActivityId });
		}

		private void buildForeignKeys(ModelBuilder builder)
		{
			builder.Entity<VacationActivity>().HasOne(va => va.Vacation).WithMany(v => v.Activities).HasForeignKey(va => va.VacationId);
		}

		private void buildConstaints(ModelBuilder builder)
		{
			builder.Entity<Vacation>().HasOne(v => v.Accommodation).WithMany().HasForeignKey(v => v.AccommodationId).OnDelete(DeleteBehavior.SetNull);
			builder.Entity<Vacation>().HasOne(v => v.Location).WithMany().HasForeignKey(v => v.LocationId).OnDelete(DeleteBehavior.Restrict);
		}

		private void seedData(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new SeedAccommodations());
			builder.ApplyConfiguration(new SeedActivities());
			builder.ApplyConfiguration(new SeedLocations());
			builder.ApplyConfiguration(new SeedVacations());
			builder.ApplyConfiguration(new SeedVacationActivities());
		}

		#endregion
	}
}

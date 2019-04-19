using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using NaijaEventAPI.Models;

namespace NaijaEventAPI.Data
{

	public class EventContext : DbContext
	{

		public EventContext(DbContextOptions<EventContext> options)
		: base(options){}

		public EventContext(){}

		public DbSet<Event> Events { get; set; }

		//http://thedatafarm.com/uncategorized/seeding-ef-with-json-data/
		public static void SeedData(IServiceProvider serviceProvider)
		{

			using (var serviceScope = serviceProvider
				.GetRequiredService<IServiceScopeFactory>().CreateScope())
   {
				var context = serviceScope
											.ServiceProvider.GetService<EventContext>();

				context.Database.EnsureCreated();

				if (context.Events.Any()) return;

				context.Events.AddRange(new Event[]
					{
				new Event
				{
					Id = 1,
					Name = "GTB Food Fare",
					StartDate = new DateTime(2018, 3, 5),
					EndDate = new DateTime(2018, 3, 8)
				},
			new Event
			{
				Id = 2,
				Name = "Diamondbank Merge",
				StartDate = new DateTime(2018, 3, 25),
				EndDate = new DateTime(2018, 3, 27)
			},
			new Event
			{
				Id = 3,
				Name = "IT Insight",
				StartDate = new DateTime(2018, 5, 7),
				EndDate = new DateTime(2018, 5, 9)
			}
			}
					);
				context.SaveChanges();


			}

		}

	}
}
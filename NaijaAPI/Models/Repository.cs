using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaijaEventAPI.Models
{
	public class Repository
	{

		private readonly List<Event> MyEvents = new List<Event>
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
        };

		public List<Event> Get()
		{
			return MyEvents;
		}

public Event Get(int id)
		{
			return MyEvents.First(t => t.Id == id);
		}

		public void Add(Event newEvent )
		{

			MyEvents.Add(newEvent);

		}

		public void Update(Event eventToUpdate)
		{

			MyEvents.Remove(MyEvents.First(t => t.Id == eventToUpdate.Id));
			Add(eventToUpdate);

		}

		public void Remove(int id)
		{
			MyEvents.Remove(MyEvents.First(t => t.Id == id));
		}

	}
}

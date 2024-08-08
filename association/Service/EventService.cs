using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using association.Model;

namespace association.Service
{
    public class EventService
    {
        private WeatherDataService _weatherDataService = new WeatherDataService();
        private List<Event> _events = new List<Event>();

        public async Task<Event> CreateEvent(string name, DateTime startDate, DateTime endDate, int registeredPeopleCount, int availableSpots, string location)
        {
            var weatherData = await _weatherDataService.GetWeatherDataForEvent(location);

            Event newEvent = new Event(startDate, endDate, name, registeredPeopleCount, availableSpots,location, weatherData);
            _events.Add(newEvent);

            return newEvent;
        }
        
        public List<Event> GetEvents()
        {
            return new List<Event>(_events);
        }
    }
}
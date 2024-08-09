using System;
using System.Collections.Generic;

namespace association.Model
{
    public class Event
    {
        #region Property
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public int RegisteredPeopleCount { get; set; }
        public int AvailableSpots { get; set; }
        public string Location { get; set; }
        public string WeatherDataFormatted { get; set; }
        public Dictionary<string, Dictionary<string, float>> WeatherData { get; set; }
        #endregion
        
        public Event(DateTime startDate, DateTime endDate, string name, int registeredPeopleCount, int availableSpots, string location, Dictionary<string, Dictionary<string, float>> weatherData)
        {
            StartDate = startDate;
            EndDate = endDate;
            Name = name;
            RegisteredPeopleCount = registeredPeopleCount;
            AvailableSpots = availableSpots;
            Location = location;
            WeatherData = weatherData;
        }
    }
}
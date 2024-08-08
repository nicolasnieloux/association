using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using association.Model;
using association.Service;
using CommunityToolkit.Mvvm.Input;

namespace associationWpf.ViewModel
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private DateTime _selectedDate;
        private ObservableCollection<Event> _events;
       
        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set
            {
                if (_events != value)
                {
                    _events = value;
                    OnPropertyChanged(nameof(Events));
                }
            }
        }
        public CalendarViewModel()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            SelectedDate = DateTime.Today;
            this.CreateEventCommand = new RelayCommand(this.OnCreateEvent);
            Events = new ObservableCollection<Event>();
        }

        public async void OnCreateEvent()
        {       
            var eventService = new EventService();
            var eventCreated = await eventService.CreateEvent("Rando", _selectedDate, _endDate, 2, 8, "Grenoble");
            if (eventCreated != null)
            {
                Events.Add(eventCreated); // Ajoute un nouvel événement à la liste après sa création.
            }
        }

        public string SelectedDateRange
        {
            get
            {
                if (EndDate < StartDate)
                    return "Invalid date range.";
                else
                    return $"{StartDate:d} - {EndDate:d}";
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                    OnPropertyChanged(nameof(SelectedDateRange));
                }
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                    OnPropertyChanged(nameof(SelectedDateRange));
                }
            }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set 
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public ICommand CreateEventCommand { get; private set; }
    }
   

}

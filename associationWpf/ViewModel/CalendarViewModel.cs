using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        private List<string> _listRando;
        private List<string> _listRandoActivites;
        private List<int> _listNumberPeople;
        private int _selectedNumberPeople;
        private int _totalSpots = 9;
        private Event _selectedEvent;
        private readonly EventService _eventService;
        

        public CalendarViewModel()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            SelectedDate = DateTime.Today;
            this.CreateEventCommand = new RelayCommand(this.OnCreateEvent);
            this.DeleteEventCommand = new RelayCommand<Event>(this.OnDeleteEvent);
            Events = new ObservableCollection<Event>();
            _listRando = new List<string> { "Crolles", "Saint-Hilaire-du-Touvet", "Le Touvet", "Saint-Ismier", "Bernin", "La Tronche", "Meylan", "Froges", "Villard-Bonnot", "Le Champ-près-Froges", "Lumbin", "Saint-Pancrasse", "Allevard", "Theys", "Tencin" };
            _listRandoActivites = new List<string> { "Trek", "Marche nordique", "Randonnée avec bivouac", "Randonnée en raquettes", "Randonnée d'altitude", "Randonnée en famille", "Randonnée avec guide", "Randonnée photo", "Randonnée botanique", "Randonnée ornithologique", "Randonnée géologique", "Randonnée aquatique", "Randonnée à thèmes", "Randonnée nocturne", "Randonnée avec ânes", "Trail running", "Randonnée en refuge", "Randonnée en itinérance", "Randonnée en circuit", "Randonnée découverte" };
            _listNumberPeople = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _eventService = new EventService();
        }

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

        public List<string> ListRando
        {
            get { return _listRando; }
            set
            {
                if (_listRando != value)
                {
                    _listRando = value;
                    OnPropertyChanged(nameof(ListRando));
                }
            }
        }

        public List<string> ListActivity
        {
            get { return _listRandoActivites; }
            set
            {
                if (_listRandoActivites != null)
                {
                    _listRandoActivites = value;
                    OnPropertyChanged(nameof(ListActivity));
                }
            }
        }

        public List<int> ListNumberPeople
        {
            get { return _listNumberPeople; }
            set
            {
                if (_listNumberPeople != null)
                {
                    _listNumberPeople = value;
                    OnPropertyChanged(nameof(ListNumberPeople));
                }
            }
        }

        public int SelectedNumberPeople
        {
            get { return _selectedNumberPeople; }
            set
            {
                _selectedNumberPeople = value;
                AvailableSpots = _totalSpots - _selectedNumberPeople;
            }
        }

        public Event SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }

        public async void OnCreateEvent()
        {

            var eventCreated = await _eventService.CreateEvent(SelectedActivity, _selectedDate, _endDate, SelectedNumberPeople, AvailableSpots, SelectedRando);
            if (eventCreated != null)
            {
                Events.Add(eventCreated); // Ajoute un nouvel événement à la liste après sa création.
            }
        }

        public async void OnDeleteEvent(Event eventToDelete)
        {
            if (eventToDelete != null)
            {
                await _eventService.DeleteEvent(eventToDelete);
                Events.Remove(eventToDelete);
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
        public ICommand DeleteEventCommand { get; private set; }
        public string SelectedRando { get; set; }

        public string SelectedActivity { get; set; }

        public int AvailableSpots { get; private set; }
    }
}
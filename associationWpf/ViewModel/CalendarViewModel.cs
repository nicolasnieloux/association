using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace associationWpf.ViewModel
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private DateTime _selectedDate;

        public CalendarViewModel()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            SelectedDate = DateTime.Today;
        }

        public CalendarViewModel(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            SelectedDate = DateTime.Today;
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
    }
}

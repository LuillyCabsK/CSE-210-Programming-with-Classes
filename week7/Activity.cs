using System;

namespace PokemonZaAndSas
{
    public abstract class Activity
    {
        private DateTime _date;
        private int _lengthInMinutes;
        private string _userName;
        private bool _useKilometers;

        public Activity(DateTime date, int lengthInMinutes, string userName, bool useKilometers)
        {
            _date = date;
            _lengthInMinutes = lengthInMinutes;
            _userName = userName;
            _useKilometers = useKilometers;
        }

        public DateTime Date => _date;
        public int LengthInMinutes => _lengthInMinutes;
        public string UserName => _userName;
        public bool UseKilometers => _useKilometers;

        // Abstract methods to be implemented by derived classes
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // Virtual method that can be overridden if needed
        public virtual string GetSummary()
        {
            string unit = _useKilometers ? "km" : "miles";
            string speedUnit = _useKilometers ? "kph" : "mph";
            string paceUnit = _useKilometers ? "min per km" : "min per mile";

            return $"{_date:dd MMM yyyy} {GetType().Name} ({_lengthInMinutes} min) - " +
                   $"Distance: {GetDistance():F1} {unit}, " +
                   $"Speed: {GetSpeed():F1} {speedUnit}, " +
                   $"Pace: {GetPace():F1} {paceUnit}";
        }

        protected string GetDistanceUnit()
        {
            return _useKilometers ? "km" : "miles";
        }

        protected string GetSpeedUnit()
        {
            return _useKilometers ? "kph" : "mph";
        }

        protected string GetPaceUnit()
        {
            return _useKilometers ? "min per km" : "min per mile";
        }
    }
}
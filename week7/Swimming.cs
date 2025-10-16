namespace PokemonZaAndSas
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int lengthInMinutes, int laps, string userName, bool useKilometers) 
            : base(date, lengthInMinutes, userName, useKilometers)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            double distanceMeters = _laps * 50.0; // 50 meters per lap
            double distanceKm = distanceMeters / 1000;
            
            if (UseKilometers)
            {
                return distanceKm;
            }
            else
            {
                return distanceKm * 0.62; // Convert to miles
            }
        }

        public override double GetSpeed()
        {
            return (GetDistance() / LengthInMinutes) * 60;
        }

        public override double GetPace()
        {
            return LengthInMinutes / GetDistance();
        }

        public override string GetSummary()
        {
            return $"{Date:dd MMM yyyy} {GetType().Name} ({LengthInMinutes} min) - " +
                   $"Distance: {GetDistance():F1} {GetDistanceUnit()}, " +
                   $"Speed: {GetSpeed():F1} {GetSpeedUnit()}, " +
                   $"Pace: {GetPace():F1} {GetPaceUnit()}, " +
                   $"Laps: {_laps}";
        }
    }
}
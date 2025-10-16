namespace PokemonZaAndSas
{
    public class Running : Activity
    {
        private double _distance;

        public Running(DateTime date, int lengthInMinutes, double distance, string userName, bool useKilometers) 
            : base(date, lengthInMinutes, userName, useKilometers)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / LengthInMinutes) * 60;
        }

        public override double GetPace()
        {
            return LengthInMinutes / GetDistance();
        }
    }
}
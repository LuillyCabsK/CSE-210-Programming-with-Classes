namespace PokemonZaAndSas
{
    public class Cycling : Activity
    {
        private double _speed;

        public Cycling(DateTime date, int lengthInMinutes, double speed, string userName, bool useKilometers) 
            : base(date, lengthInMinutes, userName, useKilometers)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return (_speed * LengthInMinutes) / 60;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            return 60 / _speed;
        }
    }
}
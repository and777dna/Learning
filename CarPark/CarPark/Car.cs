using System;

namespace CarPark 
{ 
    public class Car
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        private int _speed; 
        public string Color { get; private set; }
        public string LicensePlate { get; private set; }

        public Car(string brand, string model, string color, string licensePlate, int speed)
        {
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Color = color;
            LicensePlate = licensePlate ?? throw new ArgumentNullException(nameof(licensePlate));
            _speed = speed;
        }

        public int Speed
        {
            set
            {
                if (value >= 0)
                {
                    _speed = value;
                }
                else
                {
                    Console.WriteLine("Speed can't be set lower than 0");
                }
            }
            get
            {
                return _speed;
            }
        }

        public void ChangeColor(string color)
        {
            Color = color;
        }
    }
}
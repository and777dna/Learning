namespace CarPark
{
    public class Car
    {
            public string Brand { get; private set; }
            public string Model { get; private set; }
            public int Speed { get; private set; }      
            public string Color;  // property
            public string LicensePlate { get; private set; }

            public Car(string brand, string model, string color, string licensePlate)
            {
                Brand = brand;
                Model = model;
                Color = color;
                LicensePlate = licensePlate;
            }

            public int ChangeSpeed
            {
                set
                {
                    if (value >= 0)
                    {
                        Speed = value;
                    }
                }
                get
                {
                    return Speed;
                }
            }

            public static void ChangeColor(Car car, string color)
            {
                car.Color = color;
            }
    }
}
namespace CarPark.Car
{
    public class Car
    {
            public string Brand;      // field
            public string Model;
            public int Speed;         // field(Brand, Model, LicensePlate) NOW {"Tesla", "чёрная"};
            public string Color {get; set;}  // property
            public string LicensePlate { get; set; }
    }
}
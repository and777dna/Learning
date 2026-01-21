using System.Collections.Generic;
using System.Linq;
using CarClass = CarPark.Car.Car;

namespace CarPark.ParkingLot
{
    public class ParkingLot
    {
        public static List<CarClass> ParkingSpot = new List<CarClass>(Enumerable.Repeat<CarClass>(null, 20)).ToList();
    }
}
using System;
using CarsClass = CarPark.CarPark.CarPark;

namespace CarPark.CarPark
{
    public static class GetFastest
    {
        internal static void GetFastesCar()
        {
            var fastestSpeed = 0;
            foreach(var c in CarsClass.Cars) fastestSpeed = Math.Max(c.Speed, fastestSpeed);
            foreach(var c in CarsClass.Cars) if (c.Speed == fastestSpeed) Console.WriteLine(c.Brand);
        }
    }
}
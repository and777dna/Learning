using System;
using CarsClass = CarPark.CarPark.CarPark;

namespace CarPark.CarPark
{
    public class ShowAll
    { 
        public static void ShowAllCars() { foreach(var c in CarsClass.Cars) Console.WriteLine($"{c?.Brand} {c?.Color}  км/ч"); }
    }
}
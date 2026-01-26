using System;
using System.Collections.Generic;

namespace CarPark
{
    public class CarPark
    {
        private List<Car> _cars = new List<Car>();

        public List<Car> Cars
        {
            get { return _cars; }
            private set { _cars = value; }
        }
    }
    
    public static class AddCar
    {
        public static void AddCarToPark(Car car, List<Car> cars) {cars.Add(car);}
    }
    
    public static class ChangeRedToBlue
    {
        
    }
    
    public static class GetFastest
    {
        internal static void GetFastesCar(List<Car> cars)
        {
            var fastestSpeed = 0;
            foreach(var c in cars) fastestSpeed = Math.Max(c.Speed, fastestSpeed);
            foreach(var c in cars) if (c.Speed == fastestSpeed) Console.WriteLine(c.Brand);
        }
    }
    
    public static class ShowAll
    { 
        public static void ShowAllCars(List<Car> cars) { foreach(var c in cars) Console.WriteLine($"{c?.Brand} {c?.Color}  км/ч"); }
    }
}
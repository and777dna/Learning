using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPark
{
    public class CarPark
    {
        private List<Car> _cars = new List<Car>();
        public IReadOnlyList<Car> Cars => _cars.AsReadOnly();
        
        public void AddCarToPark(Car car) {_cars.Add(car);}
        
        internal void GetFastestCar()
        {
            var fastestSpeed = 0;
            var sortedAccordingToSpeed = _cars.OrderByDescending(car => car.Speed);
            var fastestCar = sortedAccordingToSpeed.First();
            Console.WriteLine(fastestCar.Brand);
        }
        
        public void ShowAllCars() { foreach(var c in _cars) Console.WriteLine($"{c?.Brand} {c?.Color} {c?.Speed}км/ч"); }
    }
}
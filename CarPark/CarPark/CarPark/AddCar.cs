using CarClass = CarPark.Car.Car;

using CarsClass = CarPark.CarPark.CarPark;

namespace CarPark.CarPark
{
    public static class AddCar//CarPark.CarPark.AddCar
    {
        public static void AddCarToPark(CarClass car) { CarsClass.Cars.Add(car); }
    }
}
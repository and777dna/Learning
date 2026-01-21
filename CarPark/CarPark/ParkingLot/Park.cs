using System;

using CarClass = CarPark.Car.Car;
using ParkingLotClass = CarPark.ParkingLot.ParkingLot;
using FindFreeSpotClass = CarPark.ParkingLot.FindFreeSpot;
using FindCarOnTheParkingClass = CarPark.ParkingLot.FindCarOnTheParking;

namespace CarPark.ParkingLot
{
    public class Park
    {
        public delegate void ParkingFullEvent(string message);
        public static event ParkingFullEvent Alarm;
        public static void ParkCar(CarClass car)
        {
            var freeSpotIndex = FindFreeSpotClass.FindFreeSpotParking(car);
            Console.WriteLine("freeSpotIndex Park:" + freeSpotIndex);
            if(freeSpotIndex == -1)Alarm?.Invoke("No free space on the parking lot");
            else
            {
                ParkingLotClass.ParkingSpot[freeSpotIndex] = car;
            }
           
        }

        public delegate void CarLeftEvent(string message);
        public static event CarLeftEvent Notify;
        public static void Leave(CarClass car)
        {
            int carLocationIndex = FindCarOnTheParkingClass.FindCarOnTheParkingSpot(car);//TODO: to make validation
            if (carLocationIndex == -1)
            {
                Console.WriteLine("the car is on the parking lot");
            }
            else
            {
                ParkingLotClass.ParkingSpot[carLocationIndex] = null;
                Notify?.Invoke($"Car {car.Brand} {car.Model} has left the parking spot");
            }
        }
    }
}
using System;
using CarClass = CarPark.Car.Car;
using ParkingLotClass = CarPark.ParkingLot.ParkingLot;

namespace CarPark.ParkingLot
{
    public class FindCarOnTheParking
    {
        public static int FindCarOnTheParkingSpot(CarClass car)
        {
            var carParkingSpotIndex = ParkingLotClass.ParkingSpot.FindIndex(spot => spot?.LicensePlate == car?.LicensePlate);
            return carParkingSpotIndex;
        }
    }
}
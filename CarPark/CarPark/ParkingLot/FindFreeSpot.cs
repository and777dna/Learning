using System;
using CarClass = CarPark.Car.Car;
using ParkingLotClass = CarPark.ParkingLot.ParkingLot;

namespace CarPark.ParkingLot
{
    public class FindFreeSpot
    {
        public static int FindFreeSpotParking(CarClass car)
        {
            var freeSpotIndex = ParkingLotClass.ParkingSpot.FindIndex(spot => spot == null);
            Console.WriteLine("freeSpotIndex:" + freeSpotIndex);
            return freeSpotIndex;
        }
    }
}
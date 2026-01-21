using System;
using ParkingLotClass = CarPark.ParkingLot.ParkingLot;

namespace CarPark.ParkingLot
{
    public class PrintoutParkingSpot
    {
        public static void PrintoutParkingSpots()
        {
            foreach (var spot in ParkingLotClass.ParkingSpot)
            {
                Console.WriteLine("Spot: " + spot );
            }
        }
    }
}
using System;
using ParkingLotClass = CarPark.ParkingLot.ParkingLot;

namespace CarPark.ParkingLot
{
    public class FindByLicense
    {
        internal static void FindBylicenseCar(string license)
        {
            var findedCarByLicense = ParkingLotClass.ParkingSpot.Find(car => car?.LicensePlate == license);

            Console.WriteLine("findedCarByLicense:" + findedCarByLicense?.Brand);
        }
    }
}
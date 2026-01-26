using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarPark
{
    public class ParkingLot
    {//TODO: to make this one private
        private List<Car> _parkingLot = new List<Car>(Enumerable.Repeat<Car>(null, 20)).ToList();//TODO: maybe to use constructor for this
        
        public List<Car> ParkingLotList
        {
            get { return _parkingLot; }
            private set { _parkingLot = value; }
        }

        
        internal void FindBylicenseCar(string license, List<Car> parkingLot)
        {
            var findedCarByLicense = parkingLot.Find(car => car?.LicensePlate == license);
            if(findedCarByLicense == null){Console.WriteLine($"no car on the parking lot according to {license}"); return;}

            Console.WriteLine("findedCarByLicense:" + findedCarByLicense?.Brand);
        }
        
        internal void PrintoutParkingSpots(List<Car> parkingLot)
        {
            foreach (var spot in parkingLot)
            {
                Console.WriteLine("Spot: " + spot );
            }
        }
        
        internal static int FindCar(Car car, List<Car> parkingLot)
        {
            var carParkingSpotIndex = parkingLot.FindIndex(spot => spot?.LicensePlate == car?.LicensePlate);
            if (carParkingSpotIndex == -1)
            {
                throw new FileNotFoundException("no car was founded");
            }
            return carParkingSpotIndex;
        }
        
        internal static int FindFreeSpot(List<Car> parkingLot)
        {
            var freeSpotIndex = parkingLot.FindIndex(spot => spot == null);
            if (freeSpotIndex == -1)
            {
                throw new FileNotFoundException("no free spot was founded");
            }
            Console.WriteLine("freeSpotIndex:" + freeSpotIndex);
            return freeSpotIndex;
        }
        
        public static class Action//TODO:if i can create 1 parkingLot and to access it through every method
        {
            public delegate void ParkingFullEvent(string message);
            public static event ParkingFullEvent Alarm;
            public delegate void CarLeftEvent(string message);
            public static event CarLeftEvent Notify;
            internal static void NotificateAboutParking(string notification)
            {
                Console.WriteLine(notification);
            }
            
            public static void ParkCar(Car car, List<Car> parkingLot)
            {
                var freeSpotIndex = FindFreeSpot(parkingLot);
                Console.WriteLine("freeSpotIndex Park:" + freeSpotIndex);
                if(freeSpotIndex == -1)Alarm?.Invoke("No free space on the parking lot");
                else
                {
                    parkingLot[freeSpotIndex] = car;
                }
           
            }
            
            public static void Leave(Car car, List<Car> parkingLot)
            {
                var carLocationIndex = FindCar(car, parkingLot);//TODO: to make validation
                if (carLocationIndex == -1)
                {
                    Console.WriteLine("the car is on the parking lot");
                }
                else
                {
                    parkingLot[carLocationIndex] = null;
                    Notify?.Invoke($"Car {car.Brand} {car.Model} has left the parking spot");
                }
            }
        }
    }
    
}
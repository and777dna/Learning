using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPark
{
    public class ParkingLot
    {
        private List<Car> _parkingLot = new List<Car>(Enumerable.Repeat<Car>(null, 20));

        private IReadOnlyList<Car> ParkingLotList => _parkingLot.AsReadOnly();

        
        internal void FindBylicenseCar(string license)
        {
            var findedCarByLicense = _parkingLot.Find(car => car?.LicensePlate == license);
            if(findedCarByLicense == null){Console.WriteLine($"no car on the parking lot according to {license}"); return;}

            Console.WriteLine("findedCarByLicense:" + findedCarByLicense?.Brand);
        }
        
        internal void PrintoutParkingSpots()
        {
            foreach (var spot in _parkingLot)
            {
                Console.WriteLine("Spot: " + spot );
            }
        }
        
        internal int FindCar(Car car)
        {
            var carParkingSpotIndex = _parkingLot.FindIndex(spot => spot?.LicensePlate == car?.LicensePlate);
            if (carParkingSpotIndex == -1)
            {
                throw new InvalidOperationException("no car was founded");
            }
            return carParkingSpotIndex;
        }
        
        internal int FindFreeSpot()
        {
            var freeSpotIndex = _parkingLot.FindIndex(spot => spot == null);
            if (freeSpotIndex == -1)
            {
                Alarm?.Invoke("No free space on the parking lot");
                throw new InvalidOperationException("no free spot was founded");
            }
            Console.WriteLine("freeSpotIndex:" + freeSpotIndex);
            return freeSpotIndex;
        }
        
        public delegate void ParkingFullEvent(string message);
        public event ParkingFullEvent Alarm;
        public delegate void CarLeftEvent(string message);
        public event CarLeftEvent Notify;
        internal void NotificateAboutParking(string notification)
        {
            Console.WriteLine(notification);
        }
            
        public void ParkCar(Car car)
        {
            
            var freeSpotIndex = FindFreeSpot();
            Console.WriteLine("freeSpotIndex Park:" + freeSpotIndex);
            if(freeSpotIndex == -1)Alarm?.Invoke("No free space on the parking lot");
            else
            {
                _parkingLot[freeSpotIndex] = car;
            }
           
        }
        
        public void Leave(Car car)
        {
            var carLocationIndex = FindCar(car);//TODO: to make validation
            if (carLocationIndex == -1)
            {
                throw new KeyNotFoundException();
            }
            _parkingLot[carLocationIndex] = null;
            Notify?.Invoke($"Car {car.Brand} {car.Model} has left the parking spot");
        }
    }
}
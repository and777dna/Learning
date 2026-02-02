using System;

namespace CarPark
{
    internal class Program
    {
        public static void Main()
        {
            var car1 = new Car("BMW", "x6", "красная", "8HJL274");//TODO: to add validation for licensePlate
            var car2 = new Car("Tesla", "s", "чёрная", "GTP-4590");
            var car3 = new Car("Lada", "Granta Sedan", "синяя", "LKD-3125");
            
            /*car1.Speed = 0;
            car2.Speed = 20;
            car3.Speed = 0;*/

            Car.ChangeColor(car2, "jhjhbjhb");

            var carPark1 = new CarPark();
            AddCar.AddCarToPark(car1, carPark1.Cars);
            AddCar.AddCarToPark(car2, carPark1.Cars);
            AddCar.AddCarToPark(car3, carPark1.Cars);
            
            ShowAll.ShowAllCars(carPark1.Cars);
            
            Console.WriteLine("finding the fastest car...");
            GetFastest.GetFastesCar(carPark1.Cars);

            var parking1 = new ParkingLot();
            ParkingLot.FindFreeSpot(parking1.ParkingLotList);

            ParkingLot.Action.Alarm += ParkingLot.Action.NotificateAboutParking;
            ParkingLot.Action.Notify += ParkingLot.Action.NotificateAboutParking;
            
            ParkingLot.Action.ParkCar(car1, parking1.ParkingLotList);
            ParkingLot.Action.ParkCar(car2, parking1.ParkingLotList);
            ParkingLot.Action.Leave(car1, parking1.ParkingLotList);
            
            parking1.PrintoutParkingSpots(parking1.ParkingLotList);
            
            parking1.FindBylicenseCar("GTP-4590", parking1.ParkingLotList);
            
            //AddToJsonClass.AddToJsonFile();
        }
    }
}
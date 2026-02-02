using System;

namespace CarPark
{
    internal class Program
    {
        public static void Main()
        {
            var car1 = new Car("BMW", "x6", "красная", "8HJL274", 0);//TODO: to add validation for licensePlate
            var car2 = new Car("Tesla", "s", "чёрная", "GTP-4590", 0);
            var car3 = new Car("Lada", "Granta Sedan", "синяя", "LKD-3125", 0);

            car2.ChangeColor("jhjhbjhb");

            var carPark1 = new CarPark();
            carPark1.AddCarToPark(car1);
            carPark1.AddCarToPark(car2);
            carPark1.AddCarToPark(car3);
            
            carPark1.ShowAllCars();
            
            Console.WriteLine("finding the fastest car...");
            carPark1.GetFastestCar();

            var parking1 = new ParkingLot();
            parking1.FindFreeSpot();

            parking1.Alarm += parking1.NotificateAboutParking;
            parking1.Notify += parking1.NotificateAboutParking;
            
            parking1.ParkCar(car1);
            parking1.ParkCar(car2);
            parking1.Leave(car1);
            
            parking1.PrintoutParkingSpots();
            
            parking1.FindBylicenseCar("GTP-4590");
        }
    }
}
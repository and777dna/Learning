using System;
using System.Collections.Generic;
using System.Linq;

using CarClass = CarPark.Car.Car;
//using CreateCarPropertiesClass = CarPark.Car.CreateCarProperties.SetProperties;
using CreateCarPropertiesClass = CarPark.Car.CreateCarProperties;
using ChangeColorClass = CarPark.Car.ChangeColor;
using ShowAllCarsParkClass = CarPark.CarPark.ShowAll;
using AddCarToParkClass = CarPark.CarPark.AddCar;
using ParkClass = CarPark.ParkingLot.Park;
using PrintoutParkingSpotClass =  CarPark.ParkingLot.PrintoutParkingSpot;

using GetFastestClass = CarPark.CarPark.GetFastest;

using FindByLicenseClass = CarPark.ParkingLot.FindByLicense;

namespace CarPark
{
    internal class Program
    {
        /*
            Class Car
    
            public void Accelerate() { Speed += 10; }
            public void Brake() { Speed -= 10; if (Speed < 0) Speed = 0; }
        }*/
        /*class CarPark
        {
            public static void ChangeRedToBlue()
            {
                foreach(var c in _cars)
                    if (c.Color == "красная")
                    {
                        c.ChangeColor("синяя");
                    }
            }
        }*/
        
        public static void Main(string[] args)
        {
            CarClass car1 = new CarClass();
            CarClass car2 = new CarClass();
            CarClass car3 = new CarClass();
            
            /*car1.Brand = "BMW";
            car1.Color = "красная";*/
            
            //TODO: to fix to create car through constructor
            string[] car1Params = new string[4] {"BMW", "x6", "красная", "8HJL274"};//(Brand, Model, Color, LicensePlate)
            string[] car2Params = new string[4] {"Tesla", "s", "чёрная", "GTP-4590"};
            string[] car3Params = new string[4] {"Lada", "Granta Sedan", "синяя", "LKD-3125"};

            var creator = new CreateCarPropertiesClass();
            creator.SetProperties(car1, car1Params[0], car1Params[1], car1Params[2], car1Params[3]);
            creator.SetProperties(car2, car2Params[0], car2Params[1], car2Params[2], car2Params[3]);
            creator.SetProperties(car3, car3Params[0], car3Params[1], car3Params[2], car3Params[3]);
            car1.Speed = 0;
            car2.Speed = 20;
            car3.Speed = 0;

            var colorChange = new ChangeColorClass();
            colorChange.ChangeColorCar(car2, "jhjhbjhb");

            AddCarToParkClass.AddCarToPark(car1);
            AddCarToParkClass.AddCarToPark(car2);
            AddCarToParkClass.AddCarToPark(car3);

            ShowAllCarsParkClass.ShowAllCars();
            
            Console.WriteLine("finding the fastest car...");
            GetFastestClass.GetFastesCar();
            
            ParkClass.ParkCar(car1);
            ParkClass.ParkCar(car2);
            
            PrintoutParkingSpotClass.PrintoutParkingSpots();
            ParkClass.Leave(car1);
            PrintoutParkingSpotClass.PrintoutParkingSpots();

            FindByLicenseClass.FindBylicenseCar("GTP-4590");
        }
    }
}
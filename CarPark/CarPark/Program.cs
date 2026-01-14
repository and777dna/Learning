using System;
using System.Collections.Generic;

namespace CarPark
{
    internal class Program
    {
        class Car 
        {
            public string Brand;      // field
            public int Speed;         // field
            public string Color {get; set;}  // property
    
            public void Accelerate() { Speed += 10; }
            public void Brake() { Speed -= 10; if (Speed < 0) Speed = 0; }

            public void ChangeColor(string newColor)
            {
                Color = newColor;
            }
    
            public void PrintInfo() 
            {
                Console.WriteLine($"{Brand} {Color} едет {Speed} км/ч"); 
            }
        }

        static void createCarProperties(Car car,string[] parameters)
        {
            var nameOfBrand = parameters[0];
            var color = parameters[1];
            car.Brand = nameOfBrand;
            car.Color = color;
        }
        
        class CarPark
        {
            //List<Car> cars = new List<Car>();
            static List<Car> cars = new List<Car>();
            public static void AddCar(Car car) { cars.Add(car); }
            public static void ShowAll() { foreach(var c in cars) c.PrintInfo(); }

            public static void GetFastest()
            {
                var fastestSpeed = 0;
                foreach(var c in cars) fastestSpeed = Math.Max(c.Speed, fastestSpeed);
                var findCarAccordingToSpeed = cars[0];
                foreach(var c in cars) if (c.Speed == fastestSpeed) c.PrintInfo();//findCarAccordingToSpeed = c;
                Console.WriteLine(findCarAccordingToSpeed.Brand);
                //return findCarAccordingToSpeed;
            }

            public static void ChangeRedToBlue()
            {
                foreach(var c in cars)
                    if (c.Color == "красная")
                    {
                        c.ChangeColor("синяя");
                    }
            }
        }
        
        public static void Main(string[] args)
        {
            //Создай 3 машины (BMW красная, Tesla чёрная, Lada синяя).
            //cat1 = Cat("Vasya", 3)
            Car car1 = new Car();//"BMW","красная"
            Car car2 = new Car();
            Car car3 = new Car();
            
            /*car1.Brand = "BMW";
            car1.Color = "красная";*/
            
            string[] car1params = new string[2] {"BMW", "красная"};
            string[] car2params = new string[2] {"Tesla", "чёрная"};
            string[] car3params = new string[2] {"Lada", "синяя"};
            createCarProperties(car1, car1params);
            createCarProperties(car2, car2params);
            createCarProperties(car3, car3params);
            car1.Speed = 0;
            car2.Speed = 20;
            car3.Speed = 0;
            
            //createCar({"car1", "BMW", "красная"});
            
            //car1.PrintInfo();
            //car2.PrintInfo();
            //car3.PrintInfo();
            car2.ChangeColor("jhjhbjhb");

            CarPark.AddCar(car1);
            CarPark.AddCar(car2);
            CarPark.AddCar(car3);
            
            CarPark.ShowAll();
            Console.WriteLine("finding the fastest car...");
            CarPark.GetFastest();
        }
    }
}
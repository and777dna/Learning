using CarClass = CarPark.Car.Car;

namespace CarPark.Car
{
    public class CreateCarProperties
    {
        
        public void SetProperties(CarClass car,string brand, string model, string color, string licensePlate)
        {
            /*if (brand != null && model != null && color != null && licensePlate != null)
            {
                var nameOfBrand = brand;
                var modelOfcar = model;
                var colorOfCar = color;
                var licenseOfCar = licensePlate;
            }*/
            var nameOfBrand = brand;
            var modelOfcar = model;
            var colorOfCar = color;
            var licenseOfCar = licensePlate;
            
            car.Brand = nameOfBrand;
            car.Color = color;
            car.LicensePlate = licenseOfCar;
            car.Model = model;
        }
    }
}
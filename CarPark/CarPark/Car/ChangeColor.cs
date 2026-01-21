using CarClass = CarPark.Car.Car;

namespace CarPark.Car
{
    public class ChangeColor
    {
        public void ChangeColorCar(CarClass car,string newColor)//TODO: this one should be as constructor? or some other method
        {//TODO: to add to params CarClass car
            car.Color = newColor;
        }
    }
}
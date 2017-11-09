using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var carInfo = Console.ReadLine(). Split(' ');

            var carModel = carInfo[0];
            var carFuelAmount = decimal.Parse(carInfo[1]);
            var carFuelConsumption = decimal.Parse(carInfo[2]);

            var newCar = new Car(carModel, carFuelAmount, carFuelConsumption);
            cars.Add(newCar);
        }

        var command = Console.ReadLine();

        while (command != "End")
        {
            var inputParams = command.Split(' ');

            if (inputParams[0] == "Drive")
            {
                var carModel = inputParams[1];
                var amountOfKm = int.Parse(inputParams[2]);

                var car = cars.First(c => c.Model == carModel);
                car.CalculateDistance(amountOfKm);
            }
            
            command = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
        }

    }
}


class Car
{
    public string Model { get; set; }

    public decimal FuelAmount { get; set; }

    public decimal FuelConsumption { get; set; }

    public decimal DistanceTraveled { get; set; }

    public Car(string model, decimal fuelAmount, decimal fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
        this.DistanceTraveled = 0;
    }

    public void CalculateDistance(decimal amountOfKm)
    {
        if (FuelAmount < amountOfKm * FuelConsumption)
        {
            System.Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            DistanceTraveled += amountOfKm;
            FuelAmount -= amountOfKm * FuelConsumption;
        }
    }
}

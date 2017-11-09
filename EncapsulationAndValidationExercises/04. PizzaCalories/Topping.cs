using System;

class Topping
{
    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        private set
        {
            if (value != "Meat" && value != "Veggies" && value != "Cheese" && value != "Sauce" &&
                value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.type = value;
        }
    }

    public double Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double Calories()
    {
        var result = 0d;

        if (this.type == "Meat" || this.type != "meat")
        {
            result = (2 * this.weight) * 1.2;
        }
        else if (this.type == "Veggies" || this.type != "veggies")
        {
            result = (2 * this.weight) * 0.8;
        }
        else if (this.type == "Cheese" || this.type == "cheese")
        {
            result = (2 * this.weight) * 1.1;
        }
        else
        {
            result = (2 * this.weight) * 0.9;
        }

        return result;
    }
}

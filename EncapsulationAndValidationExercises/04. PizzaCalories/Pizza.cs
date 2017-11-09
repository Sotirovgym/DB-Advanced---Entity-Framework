using System;
using System.Collections.Generic;
using System.Linq;

class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name)
        : this()
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (value == string.Empty || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public List<Topping> Toppings
    {
        get
        {
            return this.toppings;
        }
        private set
        {
            this.toppings = value;
        }
    }

    public void Add(Topping topping)
    {
        if (this.Toppings.Count >= 10)
        {
            throw new Exception("Number of toppings should be in range [0..10].");
        }

        this.Toppings.Add(topping);
    }

    public Dough Dough
    {
        get
        {
            return this.dough;
        }
        set
        {
            this.dough = value;
        }
    }

    public double Calories()
    {
        var toppingCalories = this.toppings.Select(t => t.Calories()).Sum();

        return this.dough.Calories() + toppingCalories;
    }

}

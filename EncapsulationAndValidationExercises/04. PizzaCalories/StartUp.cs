using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var pizza = new Pizza();
        var inputPizza = Console.ReadLine().Split(' ');
        try
        {
            pizza = new Pizza(inputPizza[1]);
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            return;
        }

        var inputDough = Console.ReadLine().Split(' ');

        var doughType = inputDough[1].ToLower();
        var bakingTechnique = inputDough[2].ToLower();
        var weightInGrams = double.Parse(inputDough[3]);

        try
        {
            var dough = new Dough(doughType, bakingTechnique, weightInGrams);
            pizza.Dough = dough;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        var input = Console.ReadLine();

        while (input != "END")
        {
            var tokens = input.Split(' ');

            var toppingType = tokens[1];
            var toppingWeight = double.Parse(tokens[2]);

            try
            {
                var topping = new Topping(toppingType, toppingWeight);
                pizza.Add(topping);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            input = Console.ReadLine();
        }


        Console.WriteLine($"{pizza.Name} - {pizza.Calories():f2} Calories.");

    }
}


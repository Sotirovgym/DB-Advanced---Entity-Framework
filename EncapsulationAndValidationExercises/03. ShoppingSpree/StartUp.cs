﻿using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp3
{
    static void Main(string[] args)
    {
        string allPeople = Console.ReadLine();

        List<Person> people = new List<Person>();

        string[] splitAllPeople = allPeople.Split(new[] { ';' }, StringSplitOptions.None);

        for (int i = 0; i < splitAllPeople.Length; i++)
        {
            string[] personInfo = splitAllPeople[i].Split(new[] { '=' }, StringSplitOptions.None);
            try
            {
                Person person = new Person(personInfo[0], decimal.Parse(personInfo[1]));
                people.Add(person);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        string allProducts = Console.ReadLine();
        List<Product> products = new List<Product>();

        string[] splitAllProducts = allProducts.Split(new[] { ';' }, StringSplitOptions.None);
        for (int i = 0; i < splitAllProducts.Length; i++)
        {
            string[] productInfo = splitAllProducts[i].Split(new[] { '=' }, StringSplitOptions.None);
            try
            {
                Product product = new Product(productInfo[0], decimal.Parse(productInfo[1]));
                products.Add(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        string purchaseInfo = Console.ReadLine();
        while (purchaseInfo != "END")
        {
            string[] purchase = purchaseInfo.Split(new[] { ' ' }, StringSplitOptions.None);
            string personName = purchase[0];
            string productName = purchase[1];

            Person currentPerson = people.Find(p => p.Name == personName);
            Product currentProduct = products.Find(pr => pr.Name == productName);

            if (currentPerson.Money < currentProduct.Price)
            {
                Console.WriteLine($"{personName} can't afford {productName}");
            }
            else
            {
                currentPerson.Money -= currentProduct.Price;

                foreach (var person in people.Where(p => p.Name == personName))
                {
                    person.Money = currentPerson.Money;
                    person.BagOfProducts.Add(currentProduct);
                }

                Console.WriteLine($"{personName} bought {productName}");
            }

            purchaseInfo = Console.ReadLine();
        }

        foreach (var pers in people)
        {
            pers.Print();
        }

    }
}
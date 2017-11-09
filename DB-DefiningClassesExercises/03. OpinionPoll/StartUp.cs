using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var persons = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            var personInfo = Console.ReadLine(). Split(' ');
            var personName = personInfo[0];
            var personAge = int.Parse(personInfo[1]);

            var newPerson = new Person(personName, personAge);
            persons.Add(newPerson);
        }

        foreach (var person in persons.OrderBy(p => p.Name))
        {
            if (person.Age > 30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}


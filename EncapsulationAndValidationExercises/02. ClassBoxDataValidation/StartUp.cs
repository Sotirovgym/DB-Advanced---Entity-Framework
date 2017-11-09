using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class Program
{
    static void Main()
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        var length = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        var isValid = true;
        var newBox = new Box();

        try
        {
            newBox.Length = length;
        }
        catch (Exception ex)
        {
            isValid = false;
            Console.WriteLine("Length cannot be zero or negative.");
        }

        try
        {      
            newBox.Width = width;
        }
        catch (Exception ex)
        {
            isValid = false;
            Console.WriteLine("Width cannot be zero or negative.");
        }

        try
        {
            newBox.Height = height;

            if (isValid == true)
            {
                Console.WriteLine($"Surface Area - {newBox.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {newBox.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {newBox.Volume():f2}");
            }
           
        }
        catch (Exception ex)
        {
          
            Console.WriteLine("Height cannot be zero or negative.");
        }
      
    }
}


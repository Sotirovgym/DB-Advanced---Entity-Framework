using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class StartUp
{
    static void Main()
    {
        var length = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        var newBox = new Box(length, width, height);

        Console.WriteLine($"Surface Area - {newBox.SurfaceArea():f2}");
        Console.WriteLine($"Lateral Surface Area - {newBox.LateralSurfaceArea():f2}");
        Console.WriteLine($"Volume - {newBox.Volume():f2}");       
    }
}


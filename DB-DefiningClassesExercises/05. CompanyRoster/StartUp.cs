using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            var employeeInfo = Console.ReadLine().Split();

            var name = employeeInfo[0];
            var salary = decimal.Parse(employeeInfo[1]);
            var position = employeeInfo[2];
            var department = employeeInfo[3];

            if (employeeInfo.Length == 4)
            {
                var newEmployee = new Employee(name, salary, position, department);
                employees.Add(newEmployee);
            }

            if (employeeInfo.Length == 5)
            {
                if (employeeInfo[4].Contains("@"))
                {
                    var email = employeeInfo[4];

                    var newEmployee = new Employee(name, salary, position, department);
                    newEmployee.Email = email;
                    employees.Add(newEmployee);
                }
                else
                {
                    var age = int.Parse(employeeInfo[4]);

                    var newEmployee = new Employee(name, salary, position, department);
                    newEmployee.Age = age;
                    employees.Add(newEmployee);
                }
            }
            else if (employeeInfo.Length == 6)
            {
                var email = employeeInfo[4];
                var age = int.Parse(employeeInfo[5]);
                var newEmployee = new Employee(name, salary, position, department);
                newEmployee.Email = email;
                newEmployee.Age = age;
                employees.Add(newEmployee);
            }
        }

        var result = employees
            .GroupBy(e => e.Department)
            .Select(e => new
            {
                Department = e.Key,
                AverageSalary = e.Average(emp => emp.Salary),
                Employees = e.OrderByDescending(emp => emp.Salary)
            })
            .OrderByDescending(dep => dep.AverageSalary)
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {result.Department}");

        foreach (var employee in result.Employees)
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
        }
    }
}


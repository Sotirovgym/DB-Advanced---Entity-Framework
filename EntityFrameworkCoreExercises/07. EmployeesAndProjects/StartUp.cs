using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Linq;
using System.Globalization;

namespace _07._EmployeesAndProjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniDbContext())
            {
                var employeesProjects = db.Employees
                    .Include(e => e.EmployeesProjects)
                    .ThenInclude(e => e.Project)
                    .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .ToList();

                foreach (var emp in employeesProjects)
                {
                    var managerId = emp.ManagerId;
                    var manager = db.Employees.Find(managerId);

                    Console.WriteLine($"{emp.FirstName} {emp.LastName} - Manager: {manager.FirstName} {manager.LastName}");

                    foreach (var projects in emp.EmployeesProjects)
                    {
                        var format = "M/d/yyyy h:mm:ss tt";
                        var startDate = projects.Project.StartDate.ToString(format, CultureInfo.InvariantCulture);
                        var endDate = projects.Project.EndDate.ToString();

                        if (string.IsNullOrWhiteSpace(endDate))
                        {
                            endDate = "not finished";
                        }
                        else
                        {
                            endDate = projects.Project.EndDate.Value.ToString(format, CultureInfo.InvariantCulture);
                        }

                        Console.WriteLine($"--{projects.Project.Name} - {startDate} - {endDate}");
                    }
                }
            }
        }
    }
}

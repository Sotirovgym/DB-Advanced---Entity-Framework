using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace _14._DeleteProjectById
{
    class StartUp
    {
        static void Main()
        {
            using (var db = new SoftUniDbContext())
            {
                var employeesProjects = db.EmployeesProjects
                    .Include(ep => ep.Project)
                    .Where(ep => ep.ProjectId == 2)
                    .ToList();

                foreach (var projects in employeesProjects)
                {
                    db.EmployeesProjects.Remove(projects);
                    db.SaveChanges();
                }

                var project = db.Projects.Find(2);
                db.Projects.Remove(project);

                db.SaveChanges();

                var projectsToPrint = db.Projects
                    .Select(p => new
                    {
                        p.Name
                    })
                    .Take(10)
                    .ToList();

                foreach (var proj in projectsToPrint)
                {
                    Console.WriteLine(proj.Name);
                }
            }
        }
    }
}

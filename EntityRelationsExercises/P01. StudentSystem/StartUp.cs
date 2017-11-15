using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            var context = new StudentSystemContext();

            ResetDatabase(context);
        }

        private static void ResetDatabase(StudentSystemContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.Migrate();
        }
    }
}

using System;

class Program
{
    static void Main()
    {
        var studentInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var studentFirstName = studentInfo[0];
        var studentLastName = studentInfo[1];
        var studentFacultyNumber = studentInfo[2];

        var workerInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var workerFirstName = workerInfo[0];
        var workerLastName = workerInfo[1];
        var workerWeekSalary = decimal.Parse(workerInfo[2]);
        var workerHoursPerDay = decimal.Parse(workerInfo[3]);

        try
        {
            var student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
            var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerHoursPerDay);

            Console.WriteLine(student.ToString());
            Console.WriteLine();
            Console.WriteLine(worker.ToString());
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
}
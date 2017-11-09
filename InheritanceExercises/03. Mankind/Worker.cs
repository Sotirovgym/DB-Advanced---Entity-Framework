using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workHoursPerDay = value;
        }
    }

    public override string ToString()
    {
        var result = (this.WeekSalary / 5) / this.WorkHoursPerDay;

        return $"First Name: {this.FirstName}" + Environment.NewLine +
               $"Last Name: {this.LastName}" + Environment.NewLine +
               $"Week Salary: {this.WeekSalary:f2}" + Environment.NewLine +
               $"Hours per day: {this.WorkHoursPerDay:f2}" + Environment.NewLine +
               $"Salary per hour: {result:f2}";
    }
}

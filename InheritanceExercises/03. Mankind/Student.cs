using System;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }
        private set
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetterOrDigit(value[i]))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }

            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}" + Environment.NewLine +
               $"Last Name: {this.LastName}" + Environment.NewLine +
               $"Faculty number: {this.FacultyNumber}";
    }
}

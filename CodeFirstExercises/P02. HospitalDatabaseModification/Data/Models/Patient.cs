﻿using System.Collections.Generic;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {

        }

        public Patient(int patientId, string firstName, string lastName, string address, string email, bool hasInsurance)
        {
            this.PatientId = patientId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.Email = email;
            this.HasInsurance = hasInsurance;
        }

        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new List<Visitation>();

        public ICollection<Diagnose> Diagnoses { get; set; } = new List<Diagnose>();

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new List<PatientMedicament>();
    }
}

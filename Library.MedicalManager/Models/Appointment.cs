using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalManger.Models
{

    // Class Name: Appointment
    // This class object is created and then linked to a particular physician using the 'Appointments' list in the Physician class.

    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
        public Physician Physician { get; set; }

        public Appointment(int id, DateTime date, Patient patient, Physician physician)
        {
            this.Id = id;
            this.Date = date;
            this.Patient = patient;
            this.Physician = physician;
        }
    }
}
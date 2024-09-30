using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalManger.Models { 

    // Class Name: Physician
    // The physician class is used to store specific information about physicians, such as name and specializations.
    // In addition, this class invokes the creation of an Appointment class object which is assigned to a particular physician
    // The Appointment class object is used to track details.
    public class Physician { 

        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime GraduationDate { get; set; }
        public List<string> Specializations { get; set; } = new List<string>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        
        // This function checks if the physician is available for an appointment at a particular time and date.
        // This function is used in the MedicalScheduler class

        public bool IsAvailable(DateTime appointmentDate) { 
            return !Appointments.Any(a => a.Date == appointmentDate);
        }
    }
}

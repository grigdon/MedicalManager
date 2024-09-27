using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalManger.Models {

    // Class Name: MedicalScheduler
    // This class is used to link a patient to a physician using an appointment object
    public class MedicalScheduler { 

        // Start by creating a list of Patients and a list of Physicians 

        public List<Patient> Patients = new List<Patient>();
        public List<Physician> Physicians = new List<Physician>();

        // Used to add a patient to the list of patients
        public void AddPatient(Patient patient) { 
            Patients.Add(patient);
        }

        // Used to add a physician to the list of physicians

        public void AddPhysician(Physician physician) { 
            Physicians.Add(physician);
        }

        // Used to add a medical note to a patient (duh). Searches through the list of patients, and if it
        // finds a match, it will add a note to the patient's list of medical notes. If the patient is not found,
        // it will throw an error and prevent the addition of a medical note to a null patient

        public void AddMedicalNoteToPatient(string patientName, MedicalNote note) { 

            var patient = Patients.FirstOrDefault(p => p.Name == patientName);

            if (patient != null) { 
                patient.AddMedicalNote(note);
                Console.WriteLine($"Medical note added successfully to {patientName}.");
            } else {
                Console.WriteLine($"Patient {patientName} not found.");
              }
        }

        // Used to schedule appointments with a physician.
        // This function first needs a date/time for the appointment, the patient's name, and the physician's name.
        // Then it will search through the list of patients and physicians and ensures both objects exist in their
        // respective lists. 

        public void ScheduleAppointment(DateTime date, string patientName, string physicianName) { 

            var patient = Patients.FirstOrDefault(p => p.Name == patientName);
            var physician = Physicians.FirstOrDefault(p => p.Name == physicianName);

            if (patient == null) { 
                Console.WriteLine($"Patient {patientName} not found.");
                return;
            }

            if (physician == null) { 
                Console.WriteLine($"Physician {physicianName} not found.");
                return;
            }

            // In this class, appointments can only be scheduled on an hour-to-hour basis i.e. 9:00AM, 10:00AM, etc. 
            // This if-statement checks for that.

            if (date.Minute != 0) { 
                Console.WriteLine("Appointments can only be scheduled on an hour-to-hour basis (e.g. 9:00AM, 10:00AM, etc.");
                return;
            }

            // This if-statement checks if the user is attempting to schedule an appointment outside of normal business hours

            if (date.Hour < 8 || date.Hour >= 17 || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) { 
                Console.WriteLine("Appointments can only be scheduled between 8am and 5pm, Monday to Friday.");
                return;
            }

            // Finally, this if-statement checks if the physician is available on that particular time/date selected by the user.
            // Each of these validation checks will produce a descriptive error message if a condition fails.

            if (physician.IsAvailable(date)) { 

                var appointment = new Appointment(date, patient, physician);
                physician.Appointments.Add(appointment);
                Console.WriteLine("Appointment scheduled successfully.");
            } else { 
                Console.WriteLine("The physician is already booked at this time.");
              }
        }
    }
}

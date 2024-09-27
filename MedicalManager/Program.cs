using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Library.MedicalManger.Models;


// Class Name: Program
// This class is used to store the main routine. In this main routine, I am showcasing a simple demo of the
// classes and their respective member functions. There are basic prompts implemented to demonstrate how this 
// program could be constructed in the future using a GUI instead of a terminal-based app.

public class Program
{
    static void Main(string[] args)
    {

        // Creates a new MedicalScheduler class object. Only one object is needed to provide 
        // support for all other class objects.

        MedicalScheduler scheduler = new MedicalScheduler();

        Console.WriteLine("Welcome to the Medical Scheduler!");
        Console.WriteLine();

        // This while-loop allows the user to create multiple patients for testing purposes

        string addMorePatients = "y";
        while (addMorePatients.ToLower() == "y")
        {
            // These accompanying prompts describe the member variables that will be inputted into the constructor

            Console.WriteLine("Begin entering patient details below.");

            Console.Write("Patient's Name: ");
            string patientName = Console.ReadLine();

            Console.Write("Patient's Address: ");
            string address = Console.ReadLine();

            DateTime birthDate;
            Console.Write("Patient's Birthdate (YYYY-MM-DD): ");
            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.WriteLine("Enter a valid date using YYYY-MM-DD format.");
            }

            Console.Write("Race: ");
            string race = Console.ReadLine();

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            // Creates a patient using the Patient constructor with all user inputted information
            // Then, adds to the patient to the schedule

            var patient = new Patient(patientName, address, birthDate, race, gender);
            scheduler.AddPatient(patient);

            Console.Write("Add another patient? (y/n): ");
            addMorePatients = Console.ReadLine();
            Console.WriteLine();
        }

        // Creates medical notes for each patient, if applicable

        Console.Write("\nWould you like to add medical notes for a patient? (y/n): ");

        string addMoreNotes = Console.ReadLine();

        while (addMoreNotes.ToLower() == "y")
        {
            Console.Write("Patient's Name: ");
            string patientName = Console.ReadLine();

            List<string> diagnoses = new List<string>();

            string addMoreDiagnoses = "y";

            while (addMoreDiagnoses.ToLower() == "y")
            {
                Console.Write("Patient's Diagnosis: ");
                diagnoses.Add(Console.ReadLine());

                Console.Write("Add another diagnosis? (y/n): ");
                addMoreDiagnoses = Console.ReadLine();
            }

            List<string> perscriptions = new List<string>();

            string addMorePrescriptions = "y";

            while (addMorePrescriptions.ToLower() == "y")
            {
                Console.Write("Patient's Prescription: ");
                perscriptions.Add(Console.ReadLine());

                Console.Write("Add another prescription? (y/n): ");
                addMorePrescriptions = Console.ReadLine();
            }

            var note = new MedicalNote(diagnoses, perscriptions);
            scheduler.AddMedicalNoteToPatient(patientName, note);

            Console.Write("Would you like to add more medical notes for a patient? (y/n): ");
            addMoreNotes = Console.ReadLine();
        }

        // This series of prompts is very similar to those when assigning data to patients

        Console.WriteLine("\nBegin entering physician details below:");

        string addMorePhysicians = "y";

        while (addMorePhysicians.ToLower() == "y")
        {
            Console.Write("Physician's Name: ");
            string physicianName = Console.ReadLine();

            Console.Write("Physician's License Number: ");
            string licenseNumber = Console.ReadLine();

            Console.Write("Physician's Graduation Date (YYYY-MM-DD): ");
            DateTime graduationDate;
            while (!DateTime.TryParse(Console.ReadLine(), out graduationDate))
            {
                Console.Write("Enter a valid date using YYYY-MM-DD format: ");
            }

            // This is used to assign specializations to the physician
            // It first creates a new list of strings, then allows the user to 
            // add any number of specializations. 
            // These specializations are then added to the specializations list of the physician.

            List<string> specializations = new List<string>();
            string addSpecialization = "y";
            while (addSpecialization.ToLower() == "y")
            {
                Console.Write("Enter a specialization: ");
                string specialization = Console.ReadLine();
                specializations.Add(specialization);

                Console.Write("Add another specialization? (y/n): ");
                addSpecialization = Console.ReadLine();
            }

            // Creates a physician object, then adds them to the scheduler

            var physician = new Physician(physicianName, licenseNumber, graduationDate, specializations);
            scheduler.AddPhysician(physician);

            Console.Write("Add another physician? (y/n): ");
            addMorePhysicians = Console.ReadLine();
        }

        // The following section is used for making appointments. 
        // In the way it is configured, the schedule manager is allowed
        // to make as many appointments as they wish (assuming no conflicts).

        string addMoreAppointments = "y";
        while (addMoreAppointments.ToLower() == "y")
        {
            Console.WriteLine("\nSchedule an appointment:");

            Console.Write("Patient Name: ");
            string patientName = Console.ReadLine();

            Console.Write("Physician Name: ");
            string physicianName = Console.ReadLine();

            Console.Write("Appointment Date and Time (YYYY-MM-DD HH:MM): ");
            DateTime appointmentDate;
            while (!DateTime.TryParse(Console.ReadLine(), out appointmentDate))
            {
                Console.Write("Enter a valid date using YYYY-MM-DD HH:mm format: ");
            }

            // Schedules an appointment, linking patient and physician to an appointment

            scheduler.ScheduleAppointment(appointmentDate, patientName, physicianName);

            Console.Write("Schedule another appointment? (y/n): ");
            addMoreAppointments = Console.ReadLine();
        }

        // Prints the schedule summary i.e. all patient, physician, and appointment info entered

        ScheduleSummary(scheduler);
    }

    // Function Name: ScheduleSummary
    // This function prints the following:
    //     - each patient and their entered information
    //     - each physician and their entered information
    //     - each scheduled appointment
    public static void ScheduleSummary(MedicalScheduler scheduler)
    {
        Console.WriteLine("\nStored Patients:");
        Console.WriteLine();

        foreach (var patient in scheduler.Patients)
        {
            Console.WriteLine($"Name: {patient.Name}");
            Console.WriteLine($"Address: {patient.Address}");
            Console.WriteLine($"Birthdate: {patient.BirthDate}");
            Console.WriteLine($"Race: {patient.Race}");
            Console.WriteLine($"Gender: {patient.Gender}");

            foreach (var note in patient.MedicalNotes)
            {
                Console.WriteLine("Diagnoses: " + string.Join(", ", note.Diagnoses));
                Console.WriteLine("Prescriptions: " + string.Join(", ", note.Prescriptions));
            }

            Console.WriteLine();
        }

        Console.WriteLine("\nStored Physicians:");
        Console.WriteLine();

        foreach (var physician in scheduler.Physicians)
        {
            Console.WriteLine($"Name: {physician.Name}");
            Console.WriteLine($"License Number: {physician.LicenseNumber}");
            Console.WriteLine($"Graduation Date: {physician.GraduationDate}");
            Console.WriteLine($"Specializations: {string.Join(", ", physician.Specializations)}");
            Console.WriteLine();
        }

        Console.WriteLine("\nScheduled Appointments:");
        Console.WriteLine();

        foreach (var physician in scheduler.Physicians)
        {
            Console.WriteLine($"Appointments for {physician.Name}:");
            foreach (var appointment in physician.Appointments)
            {
                Console.WriteLine($"Appointment Date: {appointment.Date}");
                Console.WriteLine($"Patient: {appointment.Patient.Name}");
                Console.WriteLine();
            }
        }
    }
}
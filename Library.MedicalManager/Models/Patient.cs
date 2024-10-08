﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalManger.Models { 

    // Class Name: Patient 
    // Creates a patient object used to keep track of name, address, date of birth, gender, and any relevant medical notes.
    // Medical notes are specified using the MedicalNote class object which is invoked during the creation of this class.

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }

        // Creates MedicalNote object for each patient.
        public List<MedicalNote> MedicalNotes { get; set; } = new List<MedicalNote>();

        // Function used to assign a medical note to a patient
        public void AddMedicalNote(MedicalNote note) { 
            MedicalNotes.Add(note);
        }
        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
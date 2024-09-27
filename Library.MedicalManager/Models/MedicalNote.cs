using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalManger.Models { 

    // Class Name: MedicalNote
    // Used to store information regarding diagnoses and prescriptions for patients.
    // Includes basic constructor. Adding information to a Patient's note is done using this class object 

    public class MedicalNote { 
        public List<string> Diagnoses { get; set; }
        public List<string> Prescriptions { get; set; }

        public MedicalNote(List<string> diagnoses, List<string> prescriptions) { 
            this.Diagnoses = diagnoses;
            this.Prescriptions = prescriptions;
        }
    }
}

﻿using Library.MedicalManger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalManager.Services
{
    public class PatientServiceProxy
    {
        public static PatientServiceProxy Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new PatientServiceProxy();
                }
                return instance;
            }
        }

        private static PatientServiceProxy? instance;
        private PatientServiceProxy()
        {
            instance = null;

            Patients = new List<Patient>
            {
                new Patient { Id = 1, Name = "John Doe" },
                new Patient { Id = 2, Name = "Jane Doe" }
            };
        }

        public int LastKey
        {
            get
            {
                if(Patients.Any())
                {
                    return Patients.Select(x => x.Id).Max();
                }
                return 0;
            }
        }

        private List<Patient> patients;

        public List<Patient> Patients
        {
            get
            {
                return patients;
            }
            private set
            {
                if (patients != value)
                {
                    patients = value;
                }
            }
        }

        public void AddPatient(Patient patient)
        {
            if(patient.Id <= 0)
            {
                patient.Id = LastKey + 1;
            }

            Patients.Add(patient);
        }

        public void DeletePatient(int id)
        {
            var patientToRemove = Patients.FirstOrDefault(p => p.Id == id);

            if(patientToRemove != null) 
            {  
                Patients.Remove(patientToRemove);
            }
        }
    }
}
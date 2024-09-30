using Library.MedicalManger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalManager.Services
{
    public class PhysicianServiceProxy
    {
        public static PhysicianServiceProxy Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhysicianServiceProxy();
                }
                return instance;
            }
        }

        private static PhysicianServiceProxy? instance;
        private PhysicianServiceProxy()
        {
            instance = null;

            Physicians = new List<Physician>
            {
                new Physician { Id = 1, Name = "Dr. John Doe" },
                new Physician { Id = 2, Name = "Jane Doe" }
            };
        }

        public int LastKey
        {
            get
            {
                if (Physicians.Any())
                {
                    return Physicians.Select(x => x.Id).Max();
                }
                return 0;
            }
        }

        public List<Physician> Physicians { get; private set; } = new List<Physician>();

        public void AddPhysician(Physician physician)
        {
            if (physician.Id <= 0)
            {
                physician.Id = LastKey + 1;
            }

            Physicians.Add(physician);
        }

        public void DeletePhysician(int id)
        {
            var physicianToRemove = Physicians.FirstOrDefault(p => p.Id == id);

            if (physicianToRemove != null)
            {
                Physicians.Remove(physicianToRemove);
            }
        }
    }
}
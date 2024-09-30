using Library.MedicalManger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalManager.Services
{
    public class AppointmentServiceProxy
    {
        public static AppointmentServiceProxy Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppointmentServiceProxy();
                }
                return instance;
            }
        }

        private static AppointmentServiceProxy? instance;
        private AppointmentServiceProxy()
        {
            instance = null;
        }

        public int LastKey
        {
            get
            {
                if (Appointments.Any())
                {
                    return Appointments.Select(x => x.Id).Max();
                }
                return 0;
            }
        }

        public List<Appointment> Appointments { get; private set; } = new List<Appointment>();

        public void AddAppointment(Appointment appointment)
        {
            if (appointment.Id <= 0)
            {
                appointment.Id = LastKey + 1;
            }

            Appointments.Add(appointment);
        }

        public void DeleteAppointment(int id)
        {
            var appointmentToRemove = Appointments.FirstOrDefault(p => p.Id == id);

            if (appointmentToRemove != null)
            {
                Appointments.Remove(appointmentToRemove);
            }
        }
    }
}
namespace App.MedicalManager.Views;
using Library.MedicalManager.Services;
using Library.MedicalManger.Models;

public partial class AppointmentManagement : ContentPage
{
    public List<Appointment> Appointments
    {
        get
        {
            return AppointmentServiceProxy.Current.Appointments;
        }
    }

    public AppointmentManagement()
    {
        InitializeComponent();

        BindingContext = this;
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}
namespace App.MedicalManager.Views;
using Library.MedicalManager.Services;
using Library.MedicalManger.Models;

public partial class PhysicianManagement : ContentPage
{
    public List<Physician> Patients
    {
        get
        {
            return PhysicianServiceProxy.Current.Physicians;
        }
    }
    public PhysicianManagement()
	{
		InitializeComponent();

		BindingContext = this;
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }
}
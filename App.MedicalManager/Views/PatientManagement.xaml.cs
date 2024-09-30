namespace App.MedicalManager.Views;
using Library.MedicalManager.Services;
using Library.MedicalManger.Models;

public partial class PatientManagement : ContentPage
{
	public List<Patient> Patients 
	{
		get
		{
			return PatientServiceProxy.Current.Patients;
		}
	}

	public PatientManagement()
	{
		InitializeComponent();

		BindingContext = this;
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//PatientDetails");
    }
}
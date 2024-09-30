using Library.MedicalManger.Models;

namespace App.MedicalManager.Views;

public partial class PatientView : ContentPage
{
	public PatientView()
	{
		InitializeComponent();
		BindingContext = new Patient();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Patients");
    }
}
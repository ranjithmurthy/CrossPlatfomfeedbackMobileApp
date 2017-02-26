using System;
using Xamarin.Forms;

namespace LoginNavigation
{
	public partial class UpcomingAppointmentsPage : ContentPage
	{
		public UpcomingAppointmentsPage ()
		{
			InitializeComponent ();
		}

		async void OnBackButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopAsync ();
		}
	}
}


using LeanMobile.Client.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeanMobile.Client.View.LiveAlgorithm
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LiveAlgorithmPage : ContentPage
	{
		public LiveAlgorithmPage ()
		{
			InitializeComponent ();
            BindingContext = new LiveAlgorithmPageViewModel();
		}
	}
}
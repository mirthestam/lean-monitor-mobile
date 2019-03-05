using LeanMobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeanMobile.View.LiveAlgorithm
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
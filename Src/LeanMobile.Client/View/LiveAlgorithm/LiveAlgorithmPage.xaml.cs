using LeanMobile.Client.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeanMobile.Client.View.LiveAlgorithm
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LiveAlgorithmPage : ContentPage
	{
        public class Parameters
        {
            public const string Id = "id";
        }

		public LiveAlgorithmPage ()
		{
			InitializeComponent();
		}
	}
}
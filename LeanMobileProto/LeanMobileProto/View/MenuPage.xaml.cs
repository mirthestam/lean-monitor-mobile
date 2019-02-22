using LeanMobileProto.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeanMobileProto.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
            BindingContext = new MenuPageViewModel();
        }
	}
}
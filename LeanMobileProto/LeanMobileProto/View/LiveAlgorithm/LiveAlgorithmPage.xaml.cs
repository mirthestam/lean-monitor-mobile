using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeanMobileProto.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeanMobileProto.View
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeanMobile.Client.View.LiveAlgorithm;
using LeanMobile.Client.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeanMobile.Client.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LiveAlgorithmsPage : ContentPage
	{
		public LiveAlgorithmsPage ()
		{
			InitializeComponent ();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (AlgorithmsListView.SelectedItem == null) return;

            AlgorithmsListView.SelectedItem = null;
            var itemPage = new LiveAlgorithmPage();
            this.Navigation.PushAsync(itemPage);
        }
    }
}
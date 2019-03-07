using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Navigation;
using Xamarin.Forms;

namespace LeanMobile.Client.View
{
	public class MainNavigationPage : NavigationPage, INavigationPageOptions
	{
		public MainNavigationPage ()
		{
		}

        public bool ClearNavigationStackOnNavigation => false;
    }
}
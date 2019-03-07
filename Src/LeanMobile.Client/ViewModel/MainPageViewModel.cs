using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;
using Prism.Navigation;

namespace LeanMobile.Client.ViewModel
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }
    }
}

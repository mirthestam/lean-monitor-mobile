using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LeanMobile.Menu;
using LeanMobile.Settings;
using Prism.Mvvm;
using Prism.Navigation;

namespace LeanMobile.Client.ViewModel
{    
    public class MenuPageViewModel : BindableBase
    {
        private readonly ISettingsService _settingsService;

        public ObservableCollection<MenuItem> MenuItems { get; set; }

        public MenuItem SelectedMenuItem { get; set; }

        public string UserId { get; set; }

        public string ProviderName { get; set; }

        public MenuPageViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;

            CreateMenu();
        }

        private void CreateMenu()
        {
            UserId = _settingsService.AuthUserToken;
            ProviderName = "QuantConnect";

            MenuItems = new ObservableCollection<MenuItem>(new List<MenuItem>
            {
                new MenuItem
                {
                    MenuItemType = MenuItemType.Live,
                    Title = "Live"
                },                
                new MenuItem
                {
                    MenuItemType = MenuItemType.Settings,
                    Title = "Settings"
                }
            });
        }       
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LeanMobileProto.Enums;
using LeanMobileProto.Model;

namespace LeanMobileProto.ViewModel
{    
    public class MenuPageViewModel
    {
        public ObservableCollection<MenuItem> MenuItems { get; set; }

        public MenuPageViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>(new List<MenuItem>
            {
                new MenuItem
                {
                    MenuItemType = MenuItemType.Live,
                    Title = "Live"
                },
                new MenuItem
                {
                    MenuItemType = MenuItemType.Projects,
                    Title = "Projects"
                },
                new MenuItem
                {
                    MenuItemType = MenuItemType.Help,
                    Title = "Help"
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

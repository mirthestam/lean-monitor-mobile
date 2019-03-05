using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LeanMobile.Enums;
using LeanMobile.Model;

namespace LeanMobile.ViewModel
{    
    public class MenuPageViewModel
    {
        public ObservableCollection<MenuItem> MenuItems { get; set; }

        public MenuItem SelectedMenuItem { get; set; }

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

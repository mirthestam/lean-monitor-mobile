using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LeanMobileProto.ViewModel
{
    public enum MenuItemType
    {
        Live,
        Projects,
        Help,
        Settings
    }

    public class MenuPageViewModel
    {
        public ObservableCollection<MenuItem> MenuItems { get; set; }

        public MenuPageViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>(new List<MenuItem>
            {
                new MenuItem
                {
                    ItemType = MenuItemType.Live,
                    Title = "Live"
                },
                new MenuItem
                {
                    ItemType = MenuItemType.Projects,
                    Title = "Projects"
                },
                new MenuItem
                {
                    ItemType = MenuItemType.Help,
                    Title = "Help"
                },
                new MenuItem
                {
                    ItemType = MenuItemType.Settings,
                    Title = "Settings"
                }
            });
        }
    }

    public class MenuItem
    {
        public string Title { get; set; }
        public MenuItemType ItemType { get; set; }
    }
}

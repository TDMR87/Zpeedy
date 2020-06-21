using System;
using System.Windows;
using System.Windows.Controls;

namespace Zpeedy_core_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainUI : Window
    {
        public MainUI()
        {
            InitializeComponent();
            this.DataContext = new MainUIViewModel();
        }

        /// <summary>
        /// Handles the OnClick event for menu items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void MenuItemTestSize_Clicked(object sender, EventArgs args)
        {
            // The selected menu item
            MenuItem checkedItem = (MenuItem)sender;

            // The parent menu the selected menu item belongs to
            MenuItem itemParent = (MenuItem)checkedItem.Parent;

            // Loop through each menu item inside the parent
            foreach (MenuItem item in itemParent.Items)
            {
                // Uncheck every other menu item except the selected menu item
                if (item != checkedItem)
                    item.IsChecked = false;
            }
        }
    }
}

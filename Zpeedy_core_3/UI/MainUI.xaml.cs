using System;
using System.Windows;

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
    }
}

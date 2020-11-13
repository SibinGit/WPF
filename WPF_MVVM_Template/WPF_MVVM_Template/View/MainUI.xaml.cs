using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_MVVM_Template.ViewModel;

namespace WPF_MVVM_Template.View
{
    /// <summary>
    /// Interaction logic for MainUI.xaml
    /// </summary>
    public partial class MainUI : Window
    {
        public MainUIViewModel ViewModel { get; } = new MainUIViewModel();
        public MainUI()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel.CloseMainUI();
        }
    }
}

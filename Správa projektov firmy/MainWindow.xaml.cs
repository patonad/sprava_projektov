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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NLog;
using PropertyChanged;
using Správa_projektov_firmy.ViewModel;
using Správa_projektov_firmy.Views;

namespace Správa_projektov_firmy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    ///

    [AddINotifyPropertyChangedInterface]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetPage(new LoginPage(this));
        }

        public void SetPage(Page page)
        {
            Frame.Content = page;
        }
        /// <summary>
        /// Vypnutie celej aplikácie 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LogManager.GetCurrentClassLogger().Info("The app is turned off");
            if (Frame.Content is ProjectPage )
            {
                if (((ProjectPage)Frame.Content).ProjectViewModel.Change)
                {
                    var result = MessageBox.Show("Do you want to save your changes ?", "Message", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        ((ProjectPage)Frame.Content).ProjectViewModel.SaveProjects();
                    }
                }
                
            }
        }
    }
}

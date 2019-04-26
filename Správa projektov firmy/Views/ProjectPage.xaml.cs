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
using Správa_projektov_firmy.ViewModel;

namespace Správa_projektov_firmy.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        public ProjectViewModel ProjectViewModel { get; set; } = new ProjectViewModel();
        public MainWindow Window { get; set; }
        public ProjectPage(MainWindow window)
        {
            InitializeComponent();
            DataContext = ProjectViewModel;
            Window = window;
        }
        /// <summary>
        /// Pridanie nového projektu s overením či je všetko zadané 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxName.Text != "" && TextBoxAbbre.Text != "" && TextBoxCusto.Text != "")
            {
                ProjectViewModel.NewProject(TextBoxName.Text, TextBoxAbbre.Text, TextBoxCusto.Text);
            }
            else
            {
                MessageBox.Show("Name or abbreviation or customer is empty");
            }

        }

        private void DataGridProjects_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ProjectViewModel.CellEditing();
        }
        /// <summary>
        /// Odhlásenie užívateľa 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            LogManager.GetCurrentClassLogger().Info("Log off user");
            if (ProjectViewModel.Change)
            {
                var result = MessageBox.Show("Do you want to save your changes?", "Message", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    ProjectViewModel.SaveCommand.Execute(null);
                    Window.SetPage(new LoginPage(Window));
                }
                else if (result == MessageBoxResult.No)
                {
                    Window.SetPage(new LoginPage(Window));
                }
            }
            else
            {
                Window.SetPage(new LoginPage(Window));
            }


        }
    }
}

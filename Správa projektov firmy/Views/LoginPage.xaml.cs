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
using Správa_projektov_firmy.ViewModel.Commands;

namespace Správa_projektov_firmy.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginViewModel ViewModel { get; set; } = new LoginViewModel();
        public MainWindow Window { get; set; }
        public LoginPage(MainWindow window)
        {
            InitializeComponent();
            Window = window;
        }
        /// <summary>
        /// Prihlásenie užívateľa 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text !="")
            {
                if (PasswordBoxPass.Password != "")
                {
                    if (ViewModel.Log(TextBoxLogin.Text, PasswordBoxPass.Password))
                    {
                        Window.SetPage(new ProjectPage(Window));
                        LogManager.GetCurrentClassLogger().Info("Login user " + TextBoxLogin.Text);
                    }
                    else
                    {
                        LabelErr.Content = "Incorrect login or password";
                    }
                }
                else
                {
                    LabelErr.Content = " Password is empty";
                }
            }
            else
            {
                LabelErr.Content = "Login is empty";
            }
        }
    }
}

using Autofac;
using Správa_projektov_firmy.Models;
using Správa_projektov_firmy.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Správa_projektov_firmy.ViewModel.Commands
{
    /// <summary>
    /// View model ktorý sa stará o prihlásenie užívateľa
    /// </summary>
    public class LoginViewModel
    {
        public Users Users { get; set; } = new Users();
        public LoginViewModel()
        {
            Load();
        }
        /// <summary>
        /// Metóda ktorá zisti ci existuje daný užívateľa s daným heslom
        /// </summary>
        /// <param name="login">Prihlasovacie meno</param>
        /// <param name="pass">Prihlasovacie heslo</param>
        /// <returns>Vráti či existuje</returns>
        public bool Log(string login, string pass)
        {
            return Users.Any(x => x.Login == login && x.Password == pass);
        }
        /// <summary>
        /// Načítanie užívateľov 
        /// </summary>
        public void Load()
        {
            LogManager.GetCurrentClassLogger().Info("Load users");
            Users = IoC.Container.Resolve<DataContext<Users>>().Load();
        }
    }
}

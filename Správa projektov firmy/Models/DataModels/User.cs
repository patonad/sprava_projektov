using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Správa_projektov_firmy.Models
{ 
    /// <summary>
    /// Trieda reprezentujúca samotého užívatela aj s príslušnými atribútmi 
    /// </summary>
    [XmlType("user")]
    public class User
    {
        public User()
        {
        }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        [XmlElement("login")]
        public string Login { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }
    }
}

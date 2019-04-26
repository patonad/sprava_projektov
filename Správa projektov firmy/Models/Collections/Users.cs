using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Správa_projektov_firmy.Models
{
    /// <summary>
    /// Kolekcia užívatelov
    /// </summary>
    [XmlRoot("users")]
    public class Users : ObservableCollection<User>
    {
    }
}

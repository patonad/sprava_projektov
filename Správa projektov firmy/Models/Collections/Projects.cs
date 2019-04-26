using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Správa_projektov_firmy.Models
{/// <summary>
/// Kolekcia projektov 
/// </summary>
    [XmlRoot("projects")]
    public class Projects : ObservableCollection<Project>
    {
    }
}

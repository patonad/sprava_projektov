using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PropertyChanged;

namespace Správa_projektov_firmy.Models
{
    /// <summary>
    /// Trieda reprezentujúca samotný projekt aj s príslušnými atribútmi 
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    [XmlType("project")]
    public class Project
    {
        public Project(string id, string name, string abbreviation, string customer)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
            Customer = customer;
        }
        public Project()
        {
           
        }
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("abbreviation")]
        public string Abbreviation { get; set; }
        [XmlElement("customer")]
        public string Customer { get; set; }
    }
}

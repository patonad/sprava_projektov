using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Správa_projektov_firmy.Models.DataModels;
using Správa_projektov_firmy.Models;

namespace Správa_projektov_firmy.Models.DataModels
{
    /// <summary>
    /// Trieda ktorá slúži na pracovanie s XML súbormi
    /// </summary>
    /// <typeparam name="T">Typ dát ktoré chceme načítať</typeparam>
    /// <typeparam name="K">Cesta k dátam</typeparam>
    public class XmlDataContext<T, K> : DataContext<T> where K : PathFile, new()
    {
        /// <summary>
        /// Metod sa stará o načítanie dát zo XML súboru
        /// </summary>
        /// <returns>Načítané dáta</returns>
        public override T Load()
        {
            var fileKey = new K();
            using (FileStream stream = new FileStream(ConfigurationManager.AppSettings[fileKey.Key], FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(stream);
            }
        }
        /// <summary>
        /// Metod sa stará o uloženie dát zo XML súboru
        /// </summary>
        /// <param name="data">Dáta na uloženie</param>
        public override void Save(T data)
        {
            var fileKey = new K();

            using (StreamWriter stream = new StreamWriter(new FileStream(ConfigurationManager.AppSettings[fileKey.Key], FileMode.Create), Encoding.GetEncoding("Windows-1250")))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stream, data, ns);

            }
        }
    }
}

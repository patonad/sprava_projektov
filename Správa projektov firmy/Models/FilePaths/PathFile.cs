using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Správa_projektov_firmy.Models
{
    /// <summary>
    /// Abstraktná trieda ktorú dedia všetky cesty k súborom 
    /// </summary>
    public abstract class PathFile
    {
        /// <summary>
        /// Kľuč k ceste v konfiguračnom súbore 
        /// </summary>
        public abstract  string Key { get;  }
    }
}

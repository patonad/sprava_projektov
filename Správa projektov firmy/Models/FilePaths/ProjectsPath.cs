using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Správa_projektov_firmy.Models
{
    /// <summary>
    /// Samotná cesta ku súboru s projektami
    /// </summary>
    public class ProjectsPath : PathFile
    {
        public override string Key { get => "FileProjects"; }

    }
}

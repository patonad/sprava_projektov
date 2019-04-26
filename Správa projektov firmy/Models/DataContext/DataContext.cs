using Správa_projektov_firmy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Správa_projektov_firmy.Models.DataModels
{
    /// <summary>
    /// Abstraktná trieda ktorú dedia triedy na ukladanie a načítavanie dát   
    /// </summary>
    /// <typeparam name="T">List ktorý chceme uložiť alebo načítať</typeparam>
    public abstract class DataContext<T>
    {
        public abstract T Load();
        public abstract void Save(T data);
    }
}

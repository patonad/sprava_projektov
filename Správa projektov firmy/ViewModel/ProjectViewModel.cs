using System;
using System.Linq;
using System.Windows.Input;
using Správa_projektov_firmy.Models;
using Správa_projektov_firmy.Commands;
using PropertyChanged;
using Správa_projektov_firmy.Models.DataModels;
using Autofac;
using NLog;

namespace Správa_projektov_firmy.ViewModel
{
    /// <summary>
    /// Viewmodel ktorý sa stará o prácu s projektami 
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class ProjectViewModel
    {
        public Projects Projects { get; set; } = new Projects();
        public bool Change { get; set; }

        public ICommand SaveCommand { get;}
        public ICommand DeleteProjectCommand { get;}
        public ICommand RevertCommand { get; }
        public ProjectViewModel()
        {
            LoadProjects();
            DeleteProjectCommand = new Command(DeleteCommandExecute, DeleteCommandEnabled);
            SaveCommand = new Command(SaveCommandExecute,EditCommandEnabled);
            RevertCommand = new Command(RevertCommandExecute, EditCommandEnabled);
        }
        /// <summary>
        /// Metóda ktorá zaznamená zmenu dát 
        /// </summary>
        public void CellEditing()
        {
            Change = true;
        }
        /// <summary>
        /// Načítanie projektov
        /// 
        /// </summary>
        private void LoadProjects()
        {
            Projects = IoC.Container.Resolve<DataContext<Projects>>().Load();
            LogManager.GetCurrentClassLogger().Info("Load projcts");
        }
        /// <summary>
        /// Uloženie projektov 
        /// </summary>
        public void SaveProjects()
        {
            LogManager.GetCurrentClassLogger().Info("Save projcts");
            IoC.Container.Resolve<DataContext<Projects>>().Save(Projects);
        }
        /// <summary>
        /// Vytvorenie nového projektu  
        /// </summary>
        /// <param name="name">Názov projektu</param>
        /// <param name="abbreviation">Skratka projektu</param>
        /// <param name="customer">Zákozník</param>
        /// <returns></returns>
        public bool NewProject(string name, string abbreviation, string customer)
        {
            if (name.Length !=0 && abbreviation.Length !=0 && customer.Length !=0)
            {
                LogManager.GetCurrentClassLogger().Info("Add new project");
                try
                {
                    int id = Projects.Select(x=>int.Parse(x.Id.Remove(0,3))).Max();
                    id++;
                    SaveNewProject(new Project("prj" + id ,name,abbreviation,customer));
                    Change = true;
                    return true;
                }
                catch (Exception e)
                {
                    LogManager.GetCurrentClassLogger().Error(e, "Error id");
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Uloženie nového projektu 
        /// </summary>
        /// <param name="project">Projekt na uloženie</param>
        public void SaveNewProject(Project project)
        {
            LogManager.GetCurrentClassLogger().Info("Save new projct");
            Projects.Add(project);
        }
        /// <summary>
        /// Povolanie vymazania projektu. Súčasť DeleteProjectCommand   
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Či je  parameter projekt</returns>
        private bool DeleteCommandEnabled(object parameter){
            return parameter is Project;
        }
        /// <summary>
        /// Samotné vymazanie projektu. Súčasť DeleteProjectCommand   
        /// </summary>
        /// <param name="parameter">Projekt na vymazanie</param>
        private void DeleteCommandExecute(object parameter)
        {
            if (parameter is Project)
            {
                Projects.Remove((Project) parameter);
                Change = true;
                LogManager.GetCurrentClassLogger().Info("Delete projct");
            }
        }
        /// <summary>
        /// Zistenie či prebehla dáka zmena v projektoch. Sučasť RevertCommandu a SaveCommandu
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Či prebehla zmena</returns>
        private bool EditCommandEnabled(object parameter)
        {
            return Change;
        }
        /// <summary>
        /// Uloženie projektov. Súčast SaveComanndu
        /// </summary>
        /// <param name="parameter"></param>
        private void SaveCommandExecute(object parameter)
        {
            SaveProjects();
            Change = false;
        }
        /// <summary>
        /// Vrátenie posledných zmien. Súčast RevertCommandu
        /// </summary>
        /// <param name="parameter"></param>
        private void RevertCommandExecute(object parameter)
        {
            LogManager.GetCurrentClassLogger().Info("Revert projcts");
            LoadProjects();
            Change = false;
        }

    }
}

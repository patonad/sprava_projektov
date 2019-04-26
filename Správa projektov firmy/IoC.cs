using Autofac;
using Správa_projektov_firmy.Models;
using Správa_projektov_firmy.Models.DataModels;

namespace Správa_projektov_firmy
{
    /// <summary>
    /// Trieda slúži na vytvorenie kontajnera a samotné zaregistrovanie tried ktoré slúžia na načítanie dát.
    /// </summary>
    public static class IoC
    {
        public static Autofac.IContainer Container { get; set; }
        /// <summary>
        /// Registrácia typov
        /// </summary>
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<XmlDataContext<Projects, ProjectsPath>>().As<DataContext<Projects>>().SingleInstance();
            builder.RegisterType<XmlDataContext<Users, UsersPath>>().As<DataContext<Users>>().SingleInstance();

            Container = builder.Build();
        }
    }
}

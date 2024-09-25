using EcoManage.Desktop.Suppliers;
using EcoManage.Domain.Handlers;
using System.Configuration;

namespace EcoManage.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DesktopConfiguration.ApiUrl = ConfigurationManager.AppSettings["ApiUrl"] ?? string.Empty;   
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormPrincipal());
            //Application.Run(new FormListSuppliers());
        }
    }
}
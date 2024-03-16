using System.Configuration;
using System.Data;
using System.Windows;

namespace CSharp_Lab2_ParsonApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        //WAS CAUSING DOUBLE WINDOWS
       
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
          
                // Set up ViewModel and bind it to the View
                var viewModel = new PersonViewModel();
                var mainWindow = new MainWindow();
                mainWindow.DataContext = viewModel;
                mainWindow.Show();               

        }
    }
}



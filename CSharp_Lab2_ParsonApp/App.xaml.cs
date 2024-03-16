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

        private bool _isMainWindowShown = false;
        /**TODO: DO SOMETHING ABT DOUBLE WINDOWS*/
        protected override void OnStartup(StartupEventArgs e)
        {
           base.OnStartup(e);

            if (!_isMainWindowShown)
            {
                // Set up ViewModel and bind it to the View
                var viewModel = new PersonViewModel();
                var mainWindow = new MainWindow();
                mainWindow.DataContext = viewModel;
                mainWindow.Show();
                _isMainWindowShown = true;
            }
            
        }
    }
}



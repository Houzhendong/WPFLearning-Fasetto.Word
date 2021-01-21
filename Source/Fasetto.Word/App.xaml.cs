using Fasetto.Word.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //setup the main application
            ApplicationSetup();

            IoC.Logger.Log("This is Debug", level:LogLevel.Debug);
            IoC.Logger.Log("This is Error", level:LogLevel.Error);
            IoC.Logger.Log("This is Informative", level:LogLevel.Informative);
            IoC.Logger.Log("This is Success", level:LogLevel.Success);
            IoC.Logger.Log("This is Verbose", level:LogLevel.Verbose);
            IoC.Logger.Log("This is Waring", level:LogLevel.Waring);

            //show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {
            IoC.Setup();

            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory());
        }
    }
}

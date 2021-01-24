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

            IoC.Task.Run(() =>
            {
                throw new ArgumentNullException();
            });

            IoC.File.WriteAllTextToFileAsync("some text", "test.txt");

            //show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {
            IoC.Setup();

            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[]
            {
                new FileLogger("log.txt"),
            }));

            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());

            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }
    }
}

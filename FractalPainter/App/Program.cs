using System;
using System.Windows.Forms;
using FractalPainting.App.Actions;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Conventions;

namespace FractalPainting.App
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                var container = new StandardKernel();
                
                container.Bind(
                    x => x.FromThisAssembly()
                        .SelectAllClasses()
                        .InheritedFrom<IUiAction>()
                        .BindAllInterfaces());

                container.Bind<Palette>().ToSelf().InSingletonScope();
                container.Bind<IImageHolder, PictureBoxImageHolder>()
                    .To<PictureBoxImageHolder>()
                    .InSingletonScope();
                container.Bind<IDragonPainterFactory>().ToFactory();

                container.Bind<IObjectSerializer>().To<XmlObjectSerializer>().WhenInjectedInto<SettingsManager>();
                container.Bind<IBlobStorage>().To<FileBlobStorage>().WhenInjectedInto<SettingsManager>();
                container.Bind<AppSettings, IImageDirectoryProvider>()
                    .ToMethod(dp => dp.Kernel.Get<SettingsManager>().Load()).InSingletonScope();
                container.Bind<ImageSettings>().ToMethod(settings => settings.Kernel.Get<AppSettings>().ImageSettings)
                    .InSingletonScope();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(container.Get<MainForm>());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
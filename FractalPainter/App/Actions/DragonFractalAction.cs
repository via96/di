using System;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;
using FractalPainting.Infrastructure.UiActions;
using Ninject;

namespace FractalPainting.App.Actions
{
    public class DragonFractalAction : IUiAction
    {
        private IImageHolder imageHolder;
        private readonly IDragonPainterFactory painterFactory;
        private readonly Func<Random, DragonSettingsGenerator> settingsFactoryFunc;

        public DragonFractalAction(IImageHolder imageHolder, IDragonPainterFactory painterFactory,
            Func<Random, DragonSettingsGenerator> settingsFactoryFunc)
        {
            this.imageHolder = imageHolder;
            this.painterFactory = painterFactory;
            this.settingsFactoryFunc = settingsFactoryFunc;
        }

        public UiActionGroup Category => UiActionGroup.Fractals;
        public string Name => "Дракон";
        public string Description => "Дракон Хартера-Хейтуэя";

        public void Perform()
        {
            var dragonSettings = CreateRandomSettings();
            SettingsForm.For(dragonSettings).ShowDialog();
            painterFactory.Create(dragonSettings).Paint();
        }

        private DragonSettings CreateRandomSettings()
        {
            return settingsFactoryFunc(new Random()).Generate();
        }
    }
}
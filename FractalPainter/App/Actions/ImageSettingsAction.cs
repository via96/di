using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.App.Actions
{
    public class ImageSettingsAction : IUiAction
    {
        private IImageHolder imageHolder;

        private ImageSettings imageSettings;
        private SettingsManager settingsManager;

        public ImageSettingsAction(IImageHolder imageHolder, SettingsManager settingsManager, ImageSettings imageSettings)
        {
            this.imageHolder = imageHolder;
            this.imageSettings = imageSettings;
            this.settingsManager = settingsManager;
        }

        public UiActionGroup Category => UiActionGroup.Settings;
        public string Name => "Изображение...";
        public string Description => "Размеры изображения";

        public void Perform()
        {
            var settings = settingsManager.Load();
            SettingsForm.For(imageSettings).ShowDialog();
            imageHolder.RecreateImage(imageSettings);
            settings.ImageSettings = imageSettings;
            settingsManager.Save(settings);
        }
    }
}
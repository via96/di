using System.ComponentModel;

namespace FractalPainting.Infrastructure.UiActions
{
    public enum UiActionGroup
    {
        [Description("Файл")]
        File = 0,
        [Description("Настройки")]
        Settings = 1,
        [Description("Фракталы")]
        Fractals = 2
    }
    
    
}
namespace FractalPainting.App.Fractals
{
    public interface IDragonPainterFactory
    {
        DragonPainter createDragonPainter(DragonSettings settings);
    }
}
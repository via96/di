namespace FractalPainting.Infrastructure.UiActions
{
    public interface IUiAction
    {
        UiActionGroup Category { get; }
        string Name { get; }
        string Description { get; }
        void Perform();
    }
}
namespace PPOIS3.Processors
{
    public interface IViewer
    {
        void View(Basket basket);
        void View(Client client);
        void View(Item item);
    }
}
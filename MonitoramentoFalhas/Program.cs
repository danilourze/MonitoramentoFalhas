using MonitoramentoFalha.Views;

namespace MonitoramentoFalhas
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var menu = new MenuView();
            menu.MostrarMenu();
        }
    }
}
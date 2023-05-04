using System.Windows.Controls;

namespace IsLibrary.Helpers
{
    public class GetUserControlInGrid
    {
        public static void ClearAndGetUserControl(Grid grid, UserControl userControl)
        {
            grid.Children.Clear();
            grid.Children.Add(userControl);
        }
        public static void GetUserControl(Grid grid, UserControl userControl)
        {         
            grid.Children.Add(userControl);
        }
    }
}

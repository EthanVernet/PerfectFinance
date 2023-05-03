using Interface.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Interface.Pages
{
    public class BasePageContentMiddle
    {
        private readonly Grid _grid;
        private readonly ColumnDefinition _leftColumn;
        private readonly ColumnDefinition _rightColumn;

        private const double WIDTH_THRESHOLD_MIN = 500;

        public BasePageContentMiddle(Grid grid, ColumnDefinition leftColumn, ColumnDefinition rightColumn)
        {
            _grid = grid;
            _leftColumn = leftColumn;
            _rightColumn = rightColumn;
        }

        public void Page_Loaded(Page page)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(page);
            mainWindow.MainWindowSizeChanged += HandleMainWindowSizeChanged;
        }

        private void HandleMainWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            InitializeResponsive(windowWidth);
        }

        public void InitializeResponsive(double windowWidth)
        {
            if (windowWidth >= WIDTH_THRESHOLD_MIN)
            {
                double columnWidthPercentage = (windowWidth - WIDTH_THRESHOLD_MIN) / WIDTH_THRESHOLD_MIN;
                _leftColumn.Width = new GridLength(columnWidthPercentage, GridUnitType.Star);
                _rightColumn.Width = new GridLength(columnWidthPercentage, GridUnitType.Star);
                SetElement(1, 1);
            }
            else
            {
                _leftColumn.Width = new GridLength(1, GridUnitType.Star);
                _rightColumn.Width = new GridLength(1, GridUnitType.Star);
                SetElement(0, 3);
            }
        }

        private void SetElement(int column, int span)
        {
            _grid.SetValue(Grid.ColumnProperty, column);
            _grid.SetValue(Grid.ColumnSpanProperty, span);
        }
    }
}

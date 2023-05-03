using System.Windows;
using System.Windows.Controls;

namespace Interface.Bases
{
    public class BasePageContentRight
    {
        private readonly Grid _controls;
        private readonly ColumnDefinition _leftColumn;
        private readonly ColumnDefinition _rightColumn;

        private const double WIDTH_THRESHOLD_MIN = 500;
        private const double WIDTH_THRESHOLD_MAX = 800;


        public BasePageContentRight(Grid main, ColumnDefinition leftColumn, ColumnDefinition rightColumn) 
        {
            _controls = main;
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
                double columnWidthPercentage = (windowWidth - WIDTH_THRESHOLD_MIN) / (WIDTH_THRESHOLD_MAX - WIDTH_THRESHOLD_MIN);

                if (columnWidthPercentage > 1) { columnWidthPercentage = 1; }
                else if (columnWidthPercentage < 0) { columnWidthPercentage = 0; }

                _leftColumn.Width = new GridLength(columnWidthPercentage, GridUnitType.Star);
                _rightColumn.Width = new GridLength(1, GridUnitType.Star);
                SetElement(1, 1);
            }
            else
            {
                _leftColumn.Width = new GridLength(0, GridUnitType.Star);
                _rightColumn.Width = new GridLength(1, GridUnitType.Star);
                SetElement(0, 2);
            }
        }

        private void SetElement(int column, int span)
        {
            _controls.SetValue(Grid.ColumnProperty, column);
            _controls.SetValue(Grid.ColumnSpanProperty, span);
        }
    }
}

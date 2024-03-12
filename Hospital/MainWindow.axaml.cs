using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Data;
using Avalonia;
using System.Globalization;
using System.Linq;

namespace Hospital
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateMargins(e.NewSize.Width, e.NewSize.Height);
        }

        private void UpdateMargins(double width, double height)
        {
            var stackPanels = grid.Children.OfType<StackPanel>();

            foreach (var stackPanel in stackPanels)
            {
                stackPanel.Margin = (Thickness)new MarginConverter().Convert(new Size(width, height), typeof(Thickness), stackPanel.Name, CultureInfo.CurrentCulture);
            }
        }
    }
}

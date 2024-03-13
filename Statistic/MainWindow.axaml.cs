using Avalonia.Controls;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;

namespace Statistic
{
    public partial class MainWindow : Window
    {
        public ISeries[] Series { get; set; }
           
        public MainWindow()
        {
            InitializeComponent();
            Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null
                }
            };
            DataContext = this;
        }
    }
}
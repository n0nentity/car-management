using GalaSoft.MvvmLight;
using OxyPlot;
using OxyPlot.Series;

namespace car_management.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private PlotModel _graphModel;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                

            }
            else
            {
                
            }
        }

        /// <summary>
        /// Gets the plot model.
        /// </summary>
        public PlotModel GraphModel
        {
            get
            {
                if (IsInDesignMode)
                {
                    // Create the plot model
                    _graphModel = new PlotModel(){Title = "Verbrauchsdaten", Subtitle = "Autoname"};

                    // Create two line series (markers are hidden by default)
                    var series1 = new LineSeries { Title = "Series 1", MarkerType = MarkerType.Circle };
                    series1.Points.Add(new DataPoint(0, 0));
                    series1.Points.Add(new DataPoint(10, 18));
                    series1.Points.Add(new DataPoint(20, 12));
                    series1.Points.Add(new DataPoint(30, 8));
                    series1.Points.Add(new DataPoint(40, 15));

                    var series2 = new LineSeries { Title = "Series 2", MarkerType = MarkerType.Square };
                    series2.Points.Add(new DataPoint(0, 4));
                    series2.Points.Add(new DataPoint(10, 12));
                    series2.Points.Add(new DataPoint(20, 16));
                    series2.Points.Add(new DataPoint(30, 25));
                    series2.Points.Add(new DataPoint(40, 5));

                    // Add the series to the plot model
                    _graphModel.Series.Add(series1);
                    _graphModel.Series.Add(series2);
                }
                return _graphModel;
            }
        }
    }
}
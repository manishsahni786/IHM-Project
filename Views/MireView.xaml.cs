using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MireWpf.ViewModels;

namespace MireWpf.Views
{
    /// <summary>
    /// Logique d'interaction pour MireView.xaml
    /// </summary>
    public partial class MireView : UserControl
    {
        public MireViewModel ViewModel { get { return DataContext as MireViewModel;} }

        private readonly Random random = new Random(1234);

        public MireView()
        {
            InitializeComponent();

            //antialiasing may decrease precision in chart, if so uncomment this line to prevent antialiasing
            //chartBlockVoile.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            //chartBlockSaut.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

            ChartGrid.SizeChanged += ChartGridOnSizeChanged;
            SizeChanged += OnWindowSizeChanged;
            Loaded += OnLoaded;
           
        }

        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChartGridOnSizeChanged(sender, e);
            SetupParam(); //Provisoire
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {

            if (ViewModel != null)
            {
                ViewModel.ChartHeight = ChartGrid.ActualHeight;
                ViewModel.ChartWidth = ChartGrid.ActualWidth;
                SetupParam(); // Provisoire
              
                /*ViewModel.SpiderChartHeight = SpiderChartGrid.ActualHeight;
                ViewModel.SpiderChartWidth = SpiderChartGrid.ActualWidth;*/
            }
            
        }

        private void ChartGridOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            if (ViewModel != null)
            {
                ViewModel.ChartHeight = ChartGrid.ActualHeight;
                ViewModel.ChartWidth = ChartGrid.ActualWidth;
                ViewModel.SpiderChartHeight = SpiderChartGrid.ActualHeight;
                ViewModel.SpiderChartWidth = SpiderChartGrid.ActualWidth;
            }
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            SetupParam();

        }
        private void SetupParam()
        {
            Params.Children.Clear();
            IDPopUp.Height = 350;

            int nbParams = 0;
            if (ViewModel.Label1 != "")
            {
                addParam(ViewModel.Label1, nbParams);
                nbParams++;
            }
            if (ViewModel.Label2 != "")
            {
                addParam(ViewModel.Label2, nbParams);
                nbParams++;
            }
            if (ViewModel.Label3 != "")
            {
                addParam(ViewModel.Label3, nbParams);
                nbParams++;
            }
            if (ViewModel.Label4 != "")
            {
                addParam(ViewModel.Label4, nbParams);
                nbParams++;
            }
            if (ViewModel.Label5 != "")
            {
                addParam(ViewModel.Label5, nbParams);
                nbParams++;
            }
        }
        private void addParam(string label, int index)
        {
            //ViewModel._parent.SaveParamLabel(index, label);
            IDPopUp.Height += 100;
            StackPanel sp = new StackPanel
            {
                Name = "Param" + index,
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            sp.Children.Add(new TextBlock
            {
                Text = label,
                FontSize = 36,
                Margin = new Thickness(20, 40, 20, 0)
            });
            sp.Children.Add(new TextBox
            {
                FontSize = 36,
                MinWidth = 100,
                MaxWidth = 900,
              //  BorderBrush = DarkSlateBlue,
              // BorderThickness = 2,
                Margin = new Thickness(20, 40, 20, 0)
            });
            Params.Children.Add(sp);
        }

        private void paramsValidation(object sender, MouseButtonEventArgs e)
        {
            int nbParams = 0;
            foreach (StackPanel child in Params.Children)
            {
                TextBox tb = (TextBox)child.Children[1];
                ViewModel._parent.SaveParamData(nbParams, tb.Text);
                nbParams++;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MireControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

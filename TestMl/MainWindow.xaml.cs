using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TestMlML.ConsoleApp;
using TestMlML.Model;
namespace TestMl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tb_canvashint.Visibility = Visibility.Collapsed;
            var p = e.MouseDevice.GetPosition(myCanvas);
            var x = Convert.ToInt32(p.X);
            var y = Convert.ToInt32(p.Y);
            if (myToggle.IsChecked ?? false)
            {
                ModelInput input = new() { X_pos = x, Y_pos = y };
                var result = ConsumeModel.Predict(input);
                addElipseWithLabel(x, y, result.Prediction + " " + Math.Round(result.Score.Max(), 2));
            }
            else
            {
                var label = mylabel.Text;
                addElipseWithLabel(x, y, label);
                ModelInput punkt = new() { Label = label, Y_pos = y, X_pos = x };
                Punkty.Add(punkt);
            }
        }

        private void addElipseWithLabel(int x, int y, string label)
        {
            Ellipse ellipse = new()
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Black
            };
            Canvas.SetTop(ellipse, y);
            Canvas.SetLeft(ellipse, x);
            myCanvas.Children.Add(ellipse);

            var pointlabel = new Label() { Content = label };
            myCanvas.Children.Add(pointlabel);
            Canvas.SetTop(pointlabel, y);
            Canvas.SetLeft(pointlabel, x + 10);
        }

        public List<ModelInput> Punkty { get; set; } = new();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModelBuilder.CreateModel(Punkty);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Punkty.Clear();
            myCanvas.Children.Clear();
            tb_canvashint.Visibility = Visibility.Visible;
        }
    }
}

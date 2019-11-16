using Microsoft.ML;
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
            Point p = e.MouseDevice.GetPosition(myCanvas);
            var x = Convert.ToInt32(p.X);
            var y = Convert.ToInt32(p.Y);
            if (myToggle.IsChecked ?? false)
            {
                var input = new ModelInput();
                input.X_pos = x;
                input.Y_pos = y;
                ModelOutput result = ConsumeModel.Predict(input);
                dodajelipse(x, y, result.Prediction + " " + result.Score.Max());
            }
            else
            {
                var label = mylabel.Text;
                dodajelipse(x, y, label);
                var punkt = new ModelInput() { Label = label, Y_pos = y, X_pos = x };
                Punkty.Add(punkt);
            }
        }

        private void dodajelipse(int x, int y, string label)
        {
            var eli = new Ellipse();
            eli.Width = 10;
            eli.Height = 10;
            eli.Fill = Brushes.Black;
            Canvas.SetTop(eli, y);
            Canvas.SetLeft(eli, x);
            myCanvas.Children.Add(eli);
            
            var textblok = new TextBlock() { Text = label };
            myCanvas.Children.Add(textblok);
            Canvas.SetTop(textblok, y);
            Canvas.SetLeft(textblok, x - 5);
        }



        public List<ModelInput> Punkty { get; set; } = new List<ModelInput>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModelBuilder.CreateModel(Punkty);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Punkty.Clear();
            myCanvas.Children.Clear();
        }
    }








}

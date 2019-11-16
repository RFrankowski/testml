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
            //Point p = Mouse.GetPosition(App.Current.MainWindow);
            var x = Convert.ToInt32(p.X);
            var y = Convert.ToInt32(p.Y);
            if (myToggle.IsChecked.HasValue && myToggle.IsChecked.Value)
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
            var textblok = new TextBlock() { Text = label };
            var r = new Ellipse();
            r.Width = 10;
            r.Height = 10;
            r.Fill = Brushes.Black;
            // Set up the position in the window, at mouse coordonate
            Canvas.SetTop(r, y);
            Canvas.SetLeft(r, x);
            // Add rectangle to the Canvas
            myCanvas.Children.Add(r);
            myCanvas.Children.Add(textblok);
            Canvas.SetTop(textblok, y);
            Canvas.SetLeft(textblok, x - 5);
        }



        public List<ModelInput> Punkty { get; set; } = new List<ModelInput>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModelBuilder.CreateModel(Punkty);
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Punkty.Clear();
            myCanvas.Children.Clear();
        }
    }








}

using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
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
            //e.MouseDevice.GetPosition(App.Current.MainWindow);

            //Point p = e.MouseDevice.GetPosition(App.Current.MainWindow);


            //Ellipse el = new Ellipse();
            //el.Height = 10;
            //el.Width = 10;
            //el.StrokeThickness = 2;
            //el.Fill = Brushes.Black;
            //Canvas.SetTop(el, p.X);
            //Canvas.SetLeft(el, p.Y);

            //myCanvas.Children.Add(el);

            Point p = Mouse.GetPosition(App.Current.MainWindow);

            // Initialize a new Rectangle
            Ellipse r = new Ellipse();

            // Set up rectangle's size
            r.Width = 10;
            r.Height = 10;

            // Set up the Background color
            r.Fill = Brushes.Black;

            var text = new TextBlock()
            {
                Text = mylabel.Text
            };

            var input = new ModelInput();
            input.X_pos = Convert.ToInt32(p.Y);
            input.Y_pos = Convert.ToInt32(p.X);
            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);
            // Use Canvas's static methods to position the text
            text.Text = result.Prediction + " " + result.Score.Max();
            Canvas.SetTop(text, p.Y);
            Canvas.SetLeft(text, p.X - 5);

            // Set up the position in the window, at mouse coordonate
            Canvas.SetTop(r, p.Y);
            Canvas.SetLeft(r, p.X);

            // Add rectangle to the Canvas
            myCanvas.Children.Add(r);
            myCanvas.Children.Add(text);
            //DrawRectWithText();

            // Add input data
            



            var pqq = new PointData() { Label = text.Text  + result.Score.ToString(), x_pos = Convert.ToInt32(p.Y), y_pos = Convert.ToInt32(p.X) };
            Punkty.Add(pqq);

            //using (var context = new BloggingContext())
            //{
            //    context.Add(pqq);
            //    context.SaveChanges();
            //}
        }



        public List<PointData> Punkty { get; set; } = new List<PointData>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var mlContext = new MLContext(seed: 0);

            //BuildTrainEvaluateAndSaveModel(mlContext);
        }
    }








}

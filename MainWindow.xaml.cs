using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CirCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const double Pi = 3.1415926535897932384626433832795;
        public double Radius { get; set; }
        public double Diameter => 2 * Radius;
        public double SurfaceArea => (4 * Pi * Radius * Radius);
        public double Circumference => (2 * Pi * Radius);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Do the calculations and update the textboxes
                Radius = double.Parse(RBox.Text);
                R2Box.Text = Radius.ToString();
                DBox.Text = Diameter.ToString();
                ABox.Text = $"{SurfaceArea}";
                CBox1.Text = $"{Circumference}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for the radius.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Set the background colour of the circle
            if (CBox.Text != "")
            {
                try
                {
                    BrushConverter converter = new BrushConverter();
                    Brush brush = (Brush)converter.ConvertFromString(CBox.Text);
                    Circle1.Fill = brush;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid color.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch
                {
                    Circle1.Fill = Brushes.Transparent;
                }
            }

            Ellipse circle = Circle1;
            circle.Width = Diameter;
            circle.Height = Diameter;
        }   
    }
}
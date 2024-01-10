using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;

namespace bc210400921
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxItems();
            radioButtonLength.IsChecked = true;
            updateUIforLength();

        }

        private void InitializeComboBoxItems()
        {
            InputType.Items.Add("Centimeter");
            InputType.Items.Add("Inches");
            InputType.Items.Add("Feet");
            InputType.Items.Add("Yards");
        }

        private void updateUIforLength()
        {
            LabelEnterValue.Content = "Enter Length in Meters";
            LabelConvertTo.Content = "Convert To: ";
            labelHeading.Content = "Length Converter";
            InputType.Items.Clear();
            InitializeComboBoxItems();
            InputType.SelectedItem = "Centimeter";
        }
        private void updateUIforTemperature()
        {
            LabelEnterValue.Content = "Enter Temperature in Celsius";
            LabelConvertTo.Content = "Convert To: ";
            labelHeading.Content = "Temperature Converter";
            InputType.Items.Clear();
            InputType.Items.Add("Fahrenheit");
            InputType.Items.Add("Kelvin");
            InputType.SelectedItem = "Fahrenheit";
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButtonLength.IsChecked == true)
            {
                updateUIforLength();
            }
            else if (radioButtonTemperature.IsChecked == true)
            {
                updateUIforTemperature();
            }
        }
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            double input;
            if (double.TryParse(textBoxInput.Text, out input))
            {
                double convertedValue = 0.0;
                string resultText = "";

                if (radioButtonLength.IsChecked == true)
                {
                    string selectedLengthunit = InputType.SelectedItem as string;
                    switch (selectedLengthunit)
                    {
                        case "Centimeter":
                            convertedValue = input * 100;
                            break;
                        case "Inches":
                            convertedValue = input / 0.0254;
                            break;
                        case "Feet":
                            convertedValue = input * 3.281;
                            break;
                        case "Yards":
                            convertedValue = input * 1.094;
                            break;
                        default:
                            MessageBox.Show("Please Select the Length", "Information", MessageBoxButton.OK);
                            return;
                    }
                    resultText = $"{input} Meters is Equal To {convertedValue:F2} {selectedLengthunit}";

                }
                else if (radioButtonTemperature.IsChecked == true)
                {
                    string selectedTemperatureUnit = InputType.SelectedItem as string;
                    switch (selectedTemperatureUnit)
                    {
                        case "Fahrenheit":
                            convertedValue = (input * 9 / 5) + 32; // Celsius to Fahrenheit
                            break;
                        case "Kelvin":
                            convertedValue = input + 273.15; // Celsius to Kelvin
                            break;
                        default:
                            MessageBox.Show("Please Select the Temperature Unit", "Information", MessageBoxButton.OK);
                            return;
                    }
                    resultText = $"{input} Celsius is Equal To {convertedValue:F2} {selectedTemperatureUnit}";
                }

                resultLabel.Content = resultText;
                textBlockResult.Text = $"{resultText}";
                textBlockResult.Visibility = Visibility.Visible;
                textBlockResult.FontWeight = FontWeights.Bold;
                textBlockResult.FontSize = 18;
            }
            else
            {
                MessageBox.Show("Please Enter the value", "Information", MessageBoxButton.OK);
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.Clear();
            resultLabel.Content = "Result: ";
            textBlockResult.Text = "";
            textBlockResult.Visibility = Visibility.Hidden;
        }
        private void InputType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }

        

       
  
}


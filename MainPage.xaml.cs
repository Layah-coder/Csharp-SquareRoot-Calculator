using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SquareRootCalculator
{
    /// <summary>
    /// Leah Oswald COP2362 C# Advanced 
    /// 3/16/2021
    /// 
    /// Create an Universal Windows Project to calculate square root without using math libraries.
    /// 
    /// Adding a message box in Windows 10.
    /// https://www.c-sharpcorner.com/UploadFile/2b876a/how-to-show-message-dialog-in-windows-10/
    /// 
    /// Referenced to calculate square root manually.
    /// https://www.programcreek.com/2012/02/java-calculate-square-root-without-using-library-method/
    /// 
    /// Labels are replaced with TextBlocks in UWP.
    /// https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/labels
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void clickCalculate(object sender, RoutedEventArgs e)
        {
            //Create pop up message objects.
            MessageDialog showDialogDouble = new MessageDialog("Please enter a double.");
            MessageDialog showDialogPositive = new MessageDialog("Please enter a positive number.");

            
            try
            {
                //Parse user input to a double.
                double input = double.Parse(inputTextBox.Text);
                //Temporary variable to hold calculations. 
                double temp;
                //Holds trial calculations and final answer to square root.
                double squareRoot = input / 2;

                //If user inputs a negative number throw Exception.
                if (input <= 0)
                    throw new Exception();

                //Do once and continue to do until temp - squareroot does not equal 0.
                do
                {
                    temp = squareRoot;
                    squareRoot = (temp + (input / temp)) / 2;
                }
                while ((temp - squareRoot) != 0);

                //Display the square root in resultsTextBlock. Change double to string.
                resultsTextBlock.Text = squareRoot.ToString();

            }
            //If parse to double was unsuccessful, such as string input.
            catch (FormatException)
            {
                resultsTextBlock.Text = "";
                 showDialogDouble.ShowAsync();
            }
            //If input was a negative number.
            catch (Exception)
            {
                resultsTextBlock.Text = "";
                showDialogPositive.ShowAsync();
            }
        }

    }
}

using System;
using System.Collections.Generic;
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

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double resultTotal = 0;
        string opChoice = "";
        bool isOpSelected = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This is the first operation which handles all number choices
        /// Aloows the option of all the numbers and no more 1 decimal point is allowed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberClick(object sender, RoutedEventArgs e)
        {
            if (resultBox.Text == "0" | isOpSelected == true) resultBox.Clear();
            Button button = (Button)sender;
            isOpSelected = false;
            if ((String)button.Content == ".")
            {
                if (!resultBox.Text.Contains("."))
                {
                    resultBox.Text += (String)button.Content;
                }
            }
            else
            {
                resultBox.Text += (String)button.Content;
            }
        }
        /// <summary>
        /// This is for the operations portion 
        /// originally we want to store the operator choice for the 
        /// user before the next one is chosen 
        /// we want to get that total
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void OperationClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (resultTotal != 0 & isOpSelected == false)
            {
                equalBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                opChoice = (String)button.Content;
                currentOp.Content = resultTotal + " " + opChoice;
                isOpSelected = true;
            }
            else
            {
                opChoice = (String)button.Content;
                resultTotal = Convert.ToDouble(resultBox.Text);
                currentOp.Content = resultTotal + " " + opChoice;
                isOpSelected = true;
            }
        }
        /// <summary>
        /// This Event  is calculaing totals 
        /// depending on the operation the user chooses
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void TotalClick(object sender, RoutedEventArgs e)
        {
            switch (opChoice)
            {
                case "+":
                    resultBox.Text = (resultTotal + Convert.ToDouble(resultBox.Text)).ToString();
                    break;
                case "-":
                    resultBox.Text = (resultTotal - Convert.ToDouble(resultBox.Text)).ToString();
                    break;
                case "*":
                    resultBox.Text = (resultTotal * Convert.ToDouble(resultBox.Text)).ToString();
                    break;
                case "/":
                    resultBox.Text = (resultTotal / Convert.ToDouble(resultBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultTotal = Convert.ToDouble(resultBox.Text);
            currentOp.Content = "";
            isOpSelected = true;
        }
        /// <summary>
        /// Here we dont want to delete everything just the current value
        /// in the results text box
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void ClearEntryClick(object sender, RoutedEventArgs e)
        {
            resultBox.Text = "0";
        }
        /// <summary>
        /// Here we are goin to clear all values to we need to 
        /// access the Textbox and the result total variable 
        /// delete the valuse in order for a fresh restart
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            resultBox.Text = "0";
            currentOp.Content = "";
            resultTotal = 0;
        }
    }
}

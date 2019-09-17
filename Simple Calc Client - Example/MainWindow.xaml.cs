/*
 * Author: Saadat Baig <support@saadat.dev>
 * Date: 17th Sep 2019
*/

using System;
using System.Windows;
using System.Windows.Media;


namespace Evaluator
{
    /// <summary>
    /// props_m4gicS
    /// </summary>
    public partial class MainWindow : Window
    {

        // globals
        public double contractor, floors, complex, sqsize;

        // safety flags
        public bool flag_contractor = false;
        public bool flag_floor = false;
        public bool flag_size = false;
        public bool flag_commercial_calc = false;

        public MainWindow()
        {
            // inits
            InitializeComponent();
            calcButton.Click += calcPrice;
        }

        // calculate price based on flags & chosen vals
        // basic flag checking U->D 
        void calcPrice(object sender, RoutedEventArgs e)
        {
            // empty TextBox
            result.Text = "";
            // contractor type
            if (ComboBoxContractorType.SelectedIndex == 0)
            {
                contractor = 500;
                flag_contractor = true;
            }
            else if (ComboBoxContractorType.SelectedIndex == 1)
            {
                contractor = 300;
                flag_contractor = true;
            }
            else if (ComboBoxContractorType.SelectedIndex == 2)
            {
                contractor = 500;
                flag_contractor = true;
            }
            else if (ComboBoxContractorType.SelectedIndex == 3)
            {
                contractor = 700;
                flag_contractor = true;
            }
            else
            {
                flag_contractor = false;
                MessageBox.Show("Please select a contractor type.", "Evaluator - ERROR");
            }

            // floor price
            if (ComboBoxFloors.SelectedIndex == 0)
            {
                floors = 400;
                flag_floor = true;
            }
            else if (ComboBoxFloors.SelectedIndex == 1)
            {
                floors = 500;
                flag_floor = true;
            }
            else if (ComboBoxFloors.SelectedIndex == 2)
            {
                floors = 600;
                flag_floor = true;
            }
            else if (ComboBoxFloors.SelectedIndex == 3)
            {
                floors = 700;
                flag_floor = true;
            }
            else
            {
                flag_floor = false;
                MessageBox.Show("Please select the floor amount.", "Evaluator - ERROR");
            }

            // complex flag
            if (flag_complex.IsChecked == true)
            {
                complex = 100;
            }
            else
            {
                complex = 0;
            }

            // overall size
            // CANNOT have both enabled at the same time or none selected, throw error in case.
            if (flag_above3k.IsChecked == true && flag_under3k.IsChecked == false)
            {
                sqsize = 200;
                flag_size = true;
            }
            else if (flag_above3k.IsChecked == false && flag_under3k.IsChecked == true)
            {
                sqsize = 100;
                flag_size = true;
            }
            else if ( (flag_above3k.IsChecked == true && flag_under3k.IsChecked == true) || (flag_above3k.IsChecked == false && flag_under3k.IsChecked == false) )
            {
                flag_size = false;
                MessageBox.Show("Please select the floor size.","Evaluator - ERROR");
            }

            // commercial
            if (flag_commercial.IsChecked == true)
            {
                flag_commercial_calc = true;
            }
            else
            {
                flag_commercial_calc = false;
            }


            // if all fields valid, generate price
            if (flag_contractor && flag_floor && flag_size)
            {
                // check for commercial
                if (flag_commercial_calc == true)
                {
                    // base price
                    double price = contractor + floors + complex + sqsize;
                    result.Foreground = Brushes.Green;
                    double commercial_extra = price * 0.1;
                    price += commercial_extra;
                    result.Text = price + " $";
                }
                else
                {
                    // just return it
                    double price = contractor + floors + complex + sqsize;
                    result.Foreground = Brushes.Green;
                    result.Text = price + " $";
                }
            }
            else
            {
                result.Text = null;
                result.Foreground = Brushes.Red;
                MessageBox.Show("Some props have not been set.\nPlease check your input.", "Evaluator");
            }
            // end: calc_Button
        }
        // end: MainWindow
    }
}

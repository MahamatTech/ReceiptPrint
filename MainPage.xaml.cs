using Adoum_FinalProject2022.Model;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Adoum_FinalProject2022
{
    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            dtpEnterPurchaseDate.SelectedDate = DateTime.Now.Date;  //Sets today as a default value for the date picker.

        }
        private async void btnPrintReceipt_Click(object sender, RoutedEventArgs e)
        {
            // We will throw an error message if the cachier forgot to fill out a section
            if (txtEnterCustomerName.Text == "")
            {

                MessageDialog messageDialog = new MessageDialog("Please fill out the customer Name.");
                await messageDialog.ShowAsync();



            }

            else if (txtEnterProductName.Text == "")
            {
                MessageDialog dialog = new MessageDialog("Please fill out Product Name.");
                await dialog.ShowAsync();


            }


            else if (txtEnterTaxRate.Text == "")
            {
                MessageDialog dialog = new MessageDialog("Please include the tax Rate");
                await dialog.ShowAsync();

            }


            else if (txtEnterPrices.Text == "")
            {
                MessageDialog dialog = new MessageDialog("The price section is Empty");
                await dialog.ShowAsync();


            }


            else
            {

                // This code obtains the user input from controls
                string customerName = txtEnterCustomerName.Text;
                string productName = txtEnterProductName.Text;
                DateTime purchaseDate = dtpEnterPurchaseDate.Date.DateTime;
                decimal taxPercent = decimal.Parse(txtEnterTaxRate.Text);
                decimal[] purchases = ConvertPurchasesToArray(txtEnterPrices.Text);
                string userName = txtEnterCustomerName.Text;
                string userProduct = txtEnterProductName.Text; 


                Receipt receipt = new Receipt(userName, userProduct, purchaseDate, purchases);
                txtReceiptStoreName.Text = receipt.StoreName;
                txtReceiptTotal.Text = Math.Round(receipt.CalculateTotal(taxPercent), 2).ToString();
                txtReceiptPurchaseValues.Text = receipt.ListItemPrices().ToString();

                txtReceiptCustomerName.Text = receipt.CustomerName;
                txtReceiptProductName.Text = receipt.ProductName;
                txtReceiptPurchaseDate.Text = receipt.PurchaseDate;
                //This line of code make the display receipt section visible
                DisplayReceipt.Visibility = Visibility.Visible;


            }




        }

        private decimal[] ConvertPurchasesToArray(string valuesList)
        {
            try
            {
                string[] tempValues = valuesList.Split(new char[] { '\r', '\n', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                decimal[] priceValues = Array.ConvertAll(tempValues, Convert.ToDecimal);
                return priceValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //Clear the user input from the Point of Sale Terminal 
            txtEnterCustomerName.Text = "";
            txtEnterProductName.Text = "";
            dtpEnterPurchaseDate.SelectedDate = DateTime.Today.Date;
            txtEnterTaxRate.Text = "0.15";
            txtEnterPrices.Text = "";
            // Hide the display receipt section
            DisplayReceipt.Visibility = Visibility.Collapsed;
        }

        private void txtEnterPrices_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtReceiptPurchaseValues_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}

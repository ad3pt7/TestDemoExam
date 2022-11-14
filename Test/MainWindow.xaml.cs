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

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities context = new Entities();
        List<Product> products = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();
            products = context.Products.ToList();
            Products.ItemsSource = products;
            ComboBoxDiscount.ItemsSource = context.Discounts.ToList();
            ComboBoxDiscount.SelectedValue = 1;
            //MessageBox.Show(products[0].ProductCost.ToString() +"  --  " +products[0].DiscountPriceAmount.ToString());
        }

        private void SearchProduct(object sender, TextChangedEventArgs e)
        {
            if(Search.Text.Length > 0)
            {

            }
            else
            {

            }
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            if (Products.SelectedItem != null)
            {
                Product editProduct = (Products.SelectedItem as Product);
                MessageBox.Show(editProduct.ProductName);

            }
            else
            {
                MessageBox.Show("Выберите объект");
            }
        }

        private void FilterByDiscount(object sender, SelectionChangedEventArgs e)
        {
            List<Product> copyProducts = products;
            switch (ComboBoxDiscount.SelectedValue)
            {
                case 1:
                    break;

                case 2:
                    copyProducts = products.Where(p => p.ProductDiscountAmount > 0 && p.ProductDiscountAmount < 4).ToList();
                    break;

            }
            MessageBox.Show(copyProducts.Count.ToString());
            Products.ItemsSource = copyProducts;
        }
    }
}

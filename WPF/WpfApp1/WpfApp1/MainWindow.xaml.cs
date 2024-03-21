using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace RestaurantBillCalculator
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<MenuItem> selectedItems = new ObservableCollection<MenuItem>();

        private List<MenuItem> beverages = new List<MenuItem>
        {
            new MenuItem { Name = "Soda", Category = "Beverage", Price = 1.95M },
            new MenuItem { Name = "Tea", Category = "Beverage", Price = 1.50M },
            new MenuItem { Name = "Coffee", Category = "Beverage", Price = 1.25M },
            new MenuItem { Name = "Mineral Water", Category = "Beverage", Price = 2.95M },
            new MenuItem { Name = "Juice", Category = "Beverage", Price = 2.50M },
            new MenuItem { Name = "Milk", Category = "Beverage", Price = 1.50M },
        };

        private List<MenuItem> appetizers = new List<MenuItem>
        {
            new MenuItem { Name = "Buffalo Wings", Category = "Appetizer", Price = 5.95M },
            new MenuItem { Name = "Buffalo Fingers", Category = "Appetizer", Price = 6.95M },
            new MenuItem { Name = "Potato Skins", Category = "Appetizer", Price = 8.95M },
            new MenuItem { Name = "Nachos ", Category = "Appetizer", Price = 8.95M },
            new MenuItem { Name = "Mushroom Caps ", Category = "Appetizer", Price = 10.95M },
            new MenuItem { Name = "Shrimp Cocktail", Category = "Appetizer", Price = 12.95M },
            new MenuItem { Name = "Chips and Salsa", Category = "Appetizer", Price = 6.95M },
        };

        private List<MenuItem> mainCourses = new List<MenuItem>
        {
            new MenuItem { Name = "Chicken Alfredo", Category = "Main Course", Price = 13.95M },
            new MenuItem { Name = "Chicken Picatta", Category = "Main Course", Price = 13.95M },
            new MenuItem { Name = "Chicken Alfredo", Category = "Main Course", Price = 15.95M },
            new MenuItem { Name = "Turkey Club", Category = "Main Course", Price = 11.95M },
            new MenuItem { Name = "Lobster Pie", Category = "Main Course", Price = 19.95M },
            new MenuItem { Name = "Prime Rib", Category = "Main Course", Price = 20.95M },
            new MenuItem { Name = "Shrimp Scampi", Category = "Main Course", Price = 18.95M },
            new MenuItem { Name = "Turkey Dinner", Category = "Main Course", Price = 13.95M },
            new MenuItem { Name = "Stuffed Chicked", Category = "Main Course", Price = 14.95M },
        };

        private List<MenuItem> desserts = new List<MenuItem>
        {
            new MenuItem { Name = "Apple Pie", Category = "Dessert", Price = 5.95M },
            new MenuItem { Name = "Sundae", Category = "Dessert", Price = 3.95M },
            new MenuItem { Name = "Carrot Cake", Category = "Dessert", Price = 5.95M },
            new MenuItem { Name = "Mud Pie", Category = "Dessert", Price = 4.95M },
            new MenuItem { Name = "Apple Crisp", Category = "Dessert", Price = 5.95M },
        };

        public MainWindow()
        {
            InitializeComponent();

            var studentNameBlock = (TextBlock)this.FindName("studentNameBlock");
            if (studentNameBlock != null)
            {
                studentNameBlock.Text = "Sajib Ghosh";
            }

            beverageComboBox.ItemsSource = beverages;
            appetizerComboBox.ItemsSource = appetizers;
            mainCourseComboBox.ItemsSource = mainCourses;
            dessertComboBox.ItemsSource = desserts;

            beverageComboBox.DisplayMemberPath = "Name";
            appetizerComboBox.DisplayMemberPath = "Name";
            mainCourseComboBox.DisplayMemberPath = "Name";
            dessertComboBox.DisplayMemberPath = "Name";

            itemsDataGrid.ItemsSource = selectedItems;

            beverageComboBox.SelectionChanged += ComboBox_SelectionChanged;
            appetizerComboBox.SelectionChanged += ComboBox_SelectionChanged;
            mainCourseComboBox.SelectionChanged += ComboBox_SelectionChanged;
            dessertComboBox.SelectionChanged += ComboBox_SelectionChanged;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is MenuItem selectedItem)
            {
                var existingItem = selectedItems.FirstOrDefault(item => item.Name == selectedItem.Name);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    selectedItem.Quantity = 1;
                    selectedItems.Add(selectedItem);
                }

                itemsDataGrid.ItemsSource = null;
                itemsDataGrid.ItemsSource = selectedItems;

                comboBox.SelectedItem = null;

                CalculateBill();
            }
        }

            private void DeleteItem_Click(object sender, RoutedEventArgs e)
            {
                if (sender is Button deleteButton && deleteButton.Content.ToString() == "Delete")
                {
                    if (deleteButton.DataContext is MenuItem selectedItem)
                    {
                        selectedItem.Quantity--;

                        if (selectedItem.Quantity <= 0)
                        {
                            selectedItems.Remove(selectedItem);
                        }

                        CalculateBill();
                    }
                }
            }

            private void CalculateBill()
            {
                decimal subtotal = 0M;
                decimal tax = 0M;

                foreach (var item in selectedItems)
                {
                    if (item.Quantity > 2)
                    {
                        subtotal += (item.Price * 2) + (item.Price * (item.Quantity - 2));
                    }
                    else
                    {
                        subtotal += item.Price * item.Quantity;
                    }
                }

                tax = subtotal * 0.10M;

                decimal total = subtotal + tax;

                subtotalTextBlock.Text = subtotal.ToString("C");
                taxTextBlock.Text = tax.ToString("C");
                totalTextBlock.Text = total.ToString("C");
            }

            private void ClearBillButton_Click(object sender, RoutedEventArgs e)
            {
                selectedItems.Clear();
                subtotalTextBlock.Text = "$0.00";
                taxTextBlock.Text = "$0.00";
                totalTextBlock.Text = "$0.00";
            }

            private void Logo_MouseDown(object sender, MouseButtonEventArgs e)
            {
                Process.Start(new ProcessStartInfo("iexplore.exe", "https://www.centennialcollege.ca"));
            }
        }

        public class MenuItem : INotifyPropertyChanged
        {

            private string name;
            private string category;
            private decimal price;
            private int quantity;

            public string Name
            {
                get { return name; }
                set { name = value; NotifyPropertyChanged(nameof(Name)); }
            }

            public string Category
            {
                get { return category; }
                set { category = value; NotifyPropertyChanged(nameof(Category)); }
            }

            public decimal Price
            {
                get { return price; }
                set { price = value; NotifyPropertyChanged(nameof(Price)); }
            }

            public int Quantity
            {
                get { return quantity; }
                set
                {
                    quantity = value;
                    NotifyPropertyChanged(nameof(Quantity));
                    RecalculateSubtotal();
                }
            }

            private double _subtotal;

            public double Subtotal
            {
                get { return _subtotal; }
                set { _subtotal = value; NotifyPropertyChanged(nameof(Subtotal)); }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            private void RecalculateSubtotal()
            {
                Subtotal = (double)(Price * Quantity);
            }
        }
} 


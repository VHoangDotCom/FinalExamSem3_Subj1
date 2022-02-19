using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FinalExamProject_Sem3.Config;
using FinalExamProject_Sem3.Entity;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinalExamProject_Sem3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private CRUD_Command crud = new CRUD_Command();
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += Page_Loaded;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListData.ItemsSource = crud.ListData();
        }

        private void txtFindName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            nameErr.Text = "";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateDate() == true)
            {
                ListData.ItemsSource = crud.FilterByName(txtFindName.Text);
            }
        }
        private bool ValidateDate()
        {
            if (txtFindName.Text == "")
            {
                nameErr.Text = "*Please choose the name !";
                return false;
            }
           
            return true;
        }


        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ListData.ItemsSource = crud.ListData();
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            nameErr.Text = "";
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.CreateContact));
        }
        private void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListData.SelectedItem != null)
            {
                Contact ct = (Contact)ListData.SelectedItem;
                txtID.Text = "ID : " + ct.ID.ToString();
                txtName.Text = "Name : " + ct.Name.ToString();
                txtPhone.Text = "Phone : " + ct.PhoneNumber.ToString();
            }
        }


    }
}

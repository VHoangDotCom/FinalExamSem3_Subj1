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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalExamProject_Sem3.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateContact : Page
    {

        CRUD_Command crud = new CRUD_Command();
        public CreateContact()
        {
            this.InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            crud.CreateRecord(txtName.Text, txtPhone.Text,nameErr.Text, phoneErr.Text);
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}

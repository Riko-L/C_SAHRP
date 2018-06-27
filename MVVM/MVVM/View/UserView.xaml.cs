using MVVM.ViewModel;
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

namespace MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour UserView.xaml
    /// </summary>
    public partial class UserView : Page
    {
        private UserViewModel _userViewModel;

        public UserView()
        {
            InitializeComponent();

            _userViewModel = new UserViewModel();

            list.ItemsSource = _userViewModel.pUsers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _userViewModel.createUser(InTxFirstName.Text, InTxLastName.Text, InTxEmail.Text);
        }
    }
}

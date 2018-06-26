using MVVM.Model;
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
    /// Logique d'interaction pour MessageView.xaml
    /// </summary>
    public partial class MessageView : Page
    {
        private MessageViewModel _messageViewModel;

        public MessageView()
        {
            InitializeComponent();

            _messageViewModel = new MessageViewModel();

            cBoxDestinataire.ItemsSource = _messageViewModel.pUsers;
            cBoxExpediteur.ItemsSource = _messageViewModel.pUsers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           _messageViewModel.setMessage(cBoxDestinataire.SelectedItem as User, cBoxExpediteur.SelectedItem as User, boxMessage.Text);
        }
    }
}

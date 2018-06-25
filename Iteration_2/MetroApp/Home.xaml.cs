using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using MetroLibrary;
using MetroLibraryGoogle;

namespace MetroApp
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page, INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string pLongitude { get; set; }
        public string pLatitude { get; set; }
        private string ptestRayon;
        public string pRayon
        {
            get { return ptestRayon; }
            set
            {
                if (ptestRayon != value)
                {
                    ptestRayon = value;
                    RaisePropertyChanged("pRayon");
                }
            }
        }

        public string pAddresse { get; set; }
        public List<LinesDescription> pLines { get; set; }
        public List<StopLines> pStopLine { get; set; }

        MetroApi metroApi;
        GoogleApi googleApi;


        public Home()
        {
            InitializeComponent();

            metroApi = new MetroApi();

            pAddresse = "36 Rue des Eaux Claires, 38100 Grenoble, France";
            pLatitude = "45.1764946";
            pLongitude = "5.709360123";
            pRayon = "1000";



            Help.Text = "Merci de renseigner les champs Longitude, Latitude et rayon ci dessous" +
                 " afin d'obtenir les différentes arrêts disponible." +
                 $" Vous pouvez aussi saisir directement une adresse '{pAddresse}'";

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Home_Grid.DataContext = this;
        }


        private void doRequete(object sender, RoutedEventArgs e)
        {

            pLongitude = replaceACaractere(Longitude.Text);
            pLatitude = replaceACaractere(Latitude.Text);
            pRayon = Rayon.Text;

            pStopLine = new List<StopLines>();

            pStopLine = metroApi.getStopLines(Convert.ToDouble(pLongitude), Convert.ToDouble(pLatitude), Convert.ToInt32(pRayon));

            grdStopLineData.ItemsSource = pStopLine;

        }

        private string replaceACaractere(string str)
        {
            if (str.Contains('.'))
            {
                return str;
            }
            else
            {
                return str.Replace(',', '.');
            }

        }

        private void doTranslateAddresstoGPS(object sender, RoutedEventArgs e)
        {
            AdressToGPSGoogle wAdressToGPSGoogles = new AdressToGPSGoogle();
            googleApi = new GoogleApi();

            wAdressToGPSGoogles = googleApi.getGpsLocation(pAddresse);

            Latitude.Text = Convert.ToString(wAdressToGPSGoogles.results[0].geometry.location.lat);
            Longitude.Text = Convert.ToString(wAdressToGPSGoogles.results[0].geometry.location.lng);

            doRequete(sender, e);

        }



        private void grdStopLineData_Selected(object sender, RoutedEventArgs e)
        {

            pLines = new List<LinesDescription>();
            StopLines items = (StopLines)grdStopLineData.SelectedItem;

            if (items != null)
            {
                foreach (string line in items.lines)
                {

                    if (line != null)
                    {
                        pLines.Add(metroApi.getInforamtionsOfLine(line)[0]);

                    }
                }
                grdLines.ItemsSource = pLines;

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Map mapPage = new Map(pStopLine, pLongitude, pLatitude, pRayon);
            this.NavigationService.Navigate(mapPage);

        }



        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

}

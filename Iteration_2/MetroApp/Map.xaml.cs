using MetroLibrary;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
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

namespace MetroApp
{
   
    public partial class Map : Page
    {

        LocationConverter locConverter = new LocationConverter();

        public List<StopLines> pStopLinesForMAP { get; set; }
        public string pLongitudePlace { get; set; }
        public string pLatitudePlace { get; set; }
        public string pRayonPlace { get; set; }

        public Map()
        {
        }

        public Map(List<StopLines> aStopLines, string aLongitudePlace, string aLatitudePlace, string aRayonPlace)

        {
            InitializeComponent();
            myMap.Focus();
            pStopLinesForMAP = aStopLines;
            pLongitudePlace = aLongitudePlace;
            pLatitudePlace = aLatitudePlace;
            pRayonPlace = aRayonPlace;

            myMap.Center = new Location(Convert.ToDouble(pLatitudePlace), Convert.ToDouble(pLongitudePlace));


            this.showPinInMap();

        }


        public void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            myMap.Children.Clear();

            
            e.Handled = true;

          
            Point mousePosition = e.GetPosition(this);
           
            Pushpin wPinPlace = new Pushpin
            {
                Location = myMap.ViewportPointToLocation(mousePosition),
                Background = new SolidColorBrush(Color.FromArgb(255, 0, 220, 10)),
                FontFamily = new FontFamily("Arial"),
                FontSize = 10.0,
                Content = "ICI",


            };

        
            myMap.Children.Add(wPinPlace);

            MetroApi wMetroApi = new MetroApi();

            List<StopLines> wStopLines = wMetroApi.getStopLines(wPinPlace.Location.Longitude, wPinPlace.Location.Latitude,1000);

            setPinPush(wStopLines);




        }

        public void showPinInMap()
        {
            Pushpin wPinPlace = new Pushpin
            {
                Location = new Location(Convert.ToDouble(pLatitudePlace), Convert.ToDouble(pLongitudePlace)),
                Background = new SolidColorBrush(Color.FromArgb(255, 0, 220, 10)),
                FontFamily = new FontFamily("Arial"),
                FontSize = 10.0,
                Content = "ICI",


            };
            ToolTipService.SetToolTip(wPinPlace, $"Coucou \n Vous êtes ici");
            myMap.Children.Add(wPinPlace);
            setPinPush(pStopLinesForMAP);
       
        }


        private void setPinPush(List<StopLines> aStopLinesForMAP)
        {

            if (aStopLinesForMAP != null)
            {
                foreach (StopLines stopMap in aStopLinesForMAP)
                {
                    string wLines = "Lines: ";
                    MetroApi metroApi = new MetroApi();
                    List<LinesDescription> wDetailsLines = new List<LinesDescription>();

                    foreach (string lines in stopMap.lines)
                    {
                        wDetailsLines = metroApi.getInforamtionsOfLine(lines);

                        wLines += $"\n {wDetailsLines.First().mode} ===> {wDetailsLines.First().shortName}";

                    }


                    Pushpin wPin = new Pushpin
                    {
                        Location = new Location(stopMap.lat, stopMap.lon),
                        Background = new SolidColorBrush(Color.FromArgb(255, 255, 100, 10)),
                        FontFamily = new FontFamily("Arial"),
                        FontSize = 10.0,
                        Content = "Stop",


                    };

                    ToolTipService.SetToolTip(wPin, $"Arrêt \n {stopMap.name} \n {wLines} ");
                    myMap.Children.Add(wPin);
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroLibrary
{
    public class FeatureCollection
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class Properties
    {
        public string NUMERO { get; set; }
        public string CODE { get; set; }
        public string COULEUR { get; set; }
        public string COULEUR_TEXTE { get; set; }
        public int PMR { get; set; }
        public string LIBELLE { get; set; }
        public List<string> ZONES_ARRET { get; set; }
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }



}
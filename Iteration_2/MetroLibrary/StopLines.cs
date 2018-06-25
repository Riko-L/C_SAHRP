using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroLibrary

{
    public  class StopLines : IEquatable<StopLines>
    {
        public string id { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public List<string> lines { get; set; }

        public bool Equals(StopLines other)
        {
            if (this.name == other.name)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class WeatherKey
    {

        private readonly string _key = "b5a7baf357c3f2f56fe1a8ca301c134b";
    
        public string KeyReturn()
          {
                return _key;
          }
        
    }
}

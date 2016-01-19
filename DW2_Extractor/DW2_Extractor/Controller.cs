using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW2_Extractor
{
    public class Controller
    {
        private static Controller controller = new Controller();
        public static Controller Instance { get { return controller; } }
    }
}

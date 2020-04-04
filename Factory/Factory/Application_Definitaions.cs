using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
     static class Application_Definitaions
    {
        enum user_Types {
            Admin=1,
            SellsManager=2,
            Clerck=3
        }//enum
        static user_Types currentusertype;
    }//Application_Definitaions
}//Factory

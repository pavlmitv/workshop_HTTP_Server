using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Common
{
   public static class Guard            //създаваме клас за валидиране на данните
    {
        public static void AgainstNull (object value, string name = null)
        {
            if (value==null)
            {
                name ??= "Value";   //means -> if name=null, then set name="Value"
                throw new ArgumentException($"{name} cannot be null");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMVC.Models
{
    public class ActionType
    {
      

        public static int Save { get { return 1; } set { } }
        public static int Update { get { return 2; } set { } }
        public static int Delete { get { return 3; } set { } }
        public static int Select { get { return 4; } set { } }


    }
}
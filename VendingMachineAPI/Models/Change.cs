using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachineAPI.Data
{
    public class Change
    {
        private int quarters;
        private int dimes;
        private int nickels;
        private int pennies;
       
        
        Change(int penniesIn)
        {
            quarters = (penniesIn / 25);
            penniesIn %= 25;
            dimes = (penniesIn / 10);
            penniesIn %= 10;
            nickels = (penniesIn / 5);
            penniesIn %= 5;
            pennies = penniesIn;
            
        }

        public int Quarters { get { return quarters; } }
        public int Dimes { get { return dimes; } }
        public int Nickels { get { return nickels; } }
        public int Pennies { get { return pennies; } }

    }
}
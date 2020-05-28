using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assignment6AirlineReservation
{
    class clsFlight
    {

        /// <summary>
        /// The Flight ID from the Database 
        /// </summary>
        public int FlightID { get; set; }
        /// <summary>
        /// The Flight Nubmer from the database
        /// </summary>
        public string Flight_Number { get; set; }
        /// <summary>
        /// The Aircraft Type from the database
        /// </summary>
        public string Aircraft_Type { get; set; }

        public override string ToString()
        {
            return Flight_Number + " - " + Aircraft_Type;
        }

    }
}

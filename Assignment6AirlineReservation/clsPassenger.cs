using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assignment6AirlineReservation
{
    class clsPassenger
    {
        /// <summary>
        /// Id assigned to the passeger in the database
        /// </summary>
        public int Passenger_ID { get; set; }
        /// <summary>
        /// Fistname of the passenger
        /// </summary>
        public string First_name { get; set; }
        /// <summary>
        /// Last name of the passenger
        /// </summary>
        public string Last_name { get; set; }
        /// <summary>
        /// Get the Seat Number 
        /// </summary>
        /// <returns></returns>
        public int Seat_Num { get; set; }

        public override string ToString()
        {
            return First_name + " " + Last_name;
        }
    }
}

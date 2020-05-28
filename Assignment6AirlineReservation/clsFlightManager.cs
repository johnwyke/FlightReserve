using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
namespace Assignment6AirlineReservation
{
    class clsFlightManager
    {
        /// <summary>
        /// List of FLight Objects.
        /// </summary>
        private List<clsFlight> Flights = new List<clsFlight>();

        private List<clsPassenger> Passengers = new List<clsPassenger>();
        /// <summary>
        /// Database object in order to pull  the information
        /// </summary>
        private clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// Gets the flight information from the database and returns a list of LFight objects
        /// </summary>
        /// <returns></returns>
        public List<clsFlight> GetFlights()
        {
            try
            {
                DataSet ds;
                clsFlight FlightOne;

                string sSQL;
                int iCount = 0;

                // Get the Flight information from the database. 
                sSQL = "Select * FROM Flight";
                ds = db.ExecuteSQLStatement(sSQL, ref iCount);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    FlightOne = new clsFlight();
                    FlightOne.FlightID = ((int)ds.Tables[0].Rows[i][0]);
                    FlightOne.Flight_Number = ds.Tables[0].Rows[i][1].ToString();
                    FlightOne.Aircraft_Type = ds.Tables[0].Rows[i][2].ToString();
                    Flights.Add(FlightOne);
                }// End For

                return Flights;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "-" + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
        /// <summary>
        /// Returns a list of taken seats 
        /// </summary>
        /// <param name="FlightId"></param>
        /// <returns></returns>
        private int GetTakenSeats(int Passenger)
        {
            DataSet ds;
            //List<int> TakenSeats = new List<int>();
            int Seat;
            string sSQL;
            int iCount = 0;
            string test;

            sSQL = "Select Seat_Number FROM Flight_Passenger_Link where passenger_ID =" + Passenger ;
            //  ds = db.ExecuteScalarSQL(sSQL, ref iCount);
            Int32.TryParse(db.ExecuteScalarSQL(sSQL), out Seat);
            return Seat;
        }

        /// <summary>
        /// Gets the Passengers on a Flight by Flight ID 
        /// </summary>
        /// <param name="FlightId"></param>
        /// <returns></returns>
        public List<clsPassenger> GetFlightPassengers(int FlightId)
        {
            try
            {
                DataSet ds;
                clsPassenger People;

                string sSQL;
                int iCount = 0;

                // Get the Flight information from the database. 
                 sSQL = "Select  * FROM Passenger where Passenger_ID IN(Select Passenger_ID FROM Flight_Passenger_Link where Flight_ID =" + FlightId + ")";
                ds = db.ExecuteSQLStatement(sSQL, ref iCount);
                Passengers.Clear();

                for (int i = 0; i < iCount; i++)
                {
                    People = new clsPassenger();
                    People.Passenger_ID = ((int)ds.Tables[0].Rows[i][0]);
                    People.First_name = ds.Tables[0].Rows[i][1].ToString();
                    People.Last_name = ds.Tables[0].Rows[i][2].ToString();
                    People.Seat_Num = GetTakenSeats((int)ds.Tables[0].Rows[i][0]);
                    Passengers.Add(People);
                }

                return Passengers;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "-" + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        public void addPassenger(string firstName, string lastName)
        {
            int newID;
            int Count = 0;
            string sSQL;

            sSQL = "Insert INTO passenger (Passegner_ID, First_name, Last_name) values (";
            db.ExecuteSQLStatement("Select * FROM Passenger ", ref Count);

            
            newID = Count + 1;
            sSQL = sSQL + newID.ToString() + ", " + firstName + ", " + lastName +")";

            db.ExecuteNonQuery(sSQL);

        }
    }

}
//}

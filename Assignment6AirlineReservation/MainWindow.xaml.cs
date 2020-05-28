using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        wndAddPassenger wndAddPass;
        clsFlightManager Flightman;
        clsFlight selFlight;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                wndAddPass = new wndAddPassenger();
                Flightman = new clsFlightManager();
                selFlight = new clsFlight();
                cbChooseFlight.ItemsSource = Flightman.GetFlights();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selFlight = (clsFlight)cbChooseFlight.SelectedItem;
              
                cbChoosePassenger.IsEnabled = true;
                gPassengerCommands.IsEnabled = true;
                if (selFlight.FlightID == 1)
                {
                    CanvasA380.Visibility = Visibility.Hidden;
                    Canvas767.Visibility = Visibility.Visible;
                }
                else
                {
                    Canvas767.Visibility = Visibility.Hidden;
                    CanvasA380.Visibility = Visibility.Visible;
                }
                cbChoosePassenger.ItemsSource = null;                
                cbChoosePassenger.ItemsSource = Flightman.GetFlightPassengers(selFlight.FlightID);

                //colorSeats(selFlight.FlightID);

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndAddPass = new wndAddPassenger();
                wndAddPass.ShowDialog();

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        private void colorSeats(int FlightNum)
        {
            clsPassenger currPass;
            int Seat_Count;
            int passCount = cbChoosePassenger.Items.Count;
            int Seat;



            if (Canvas767.IsVisible)
                Seat_Count = c767_Seats.Children.Count;
            else
                Seat_Count = cA380_Seats.Children.Count;
           
            for (int i = 0; i < passCount; i++)
            {
                for (int j = 0; j < Seat_Count; j++)
                {
                    //Need to get Passenger Seat and compare against all Lablels in Canvas. 
                    //currPass = cbChoosePassenger.
                    //if ()
                    //{

                    //}
                }
                
            }
            
        }

        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}

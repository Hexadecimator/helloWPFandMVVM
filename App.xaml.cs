using ReservoomMVVM.Models;
using ReservoomMVVM.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ReservoomMVVM {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            Hotel hotel = new Hotel("Logan View");

            hotel.MakeReservation(new Reservation(
                new RoomID(1, 3), new DateTime(2022, 4, 20), new DateTime(2022, 5, 20), "Logan"));

            hotel.MakeReservation(new Reservation(
                new RoomID(1, 3), new DateTime(2022, 6, 20), new DateTime(2022, 7, 20), "Logan"));

            hotel.MakeReservation(new Reservation(
                new RoomID(2, 1), new DateTime(2022, 3, 3), new DateTime(2022, 4, 4), "Roberto"));

            try {
                hotel.MakeReservation(new Reservation(
                new RoomID(2, 1), new DateTime(2022, 3, 3), new DateTime(2022, 4, 4), "Batman"));
            }
            catch ( ReservationConflictException ex ) {
                MessageBox.Show(ex.Message);
            }

            IEnumerable<Reservation> reservations = hotel.GetReservationsForUser("Logan");

            base.OnStartup(e);
        }
    }
}

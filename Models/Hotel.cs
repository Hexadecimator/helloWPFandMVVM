using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservoomMVVM.Models {
    internal class Hotel {
        private readonly ReservationBook _reservationBook;

        public string Name { get; }

        public Hotel(string name) {
            Name = name;
            _reservationBook = new ReservationBook();
        }

        /// <summary>
        /// Get the reservations for a user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public IEnumerable<Reservation> GetReservationsForUser(string username) {
            return _reservationBook.GetReservationsForUser(username);
        }

        public void MakeReservation(Reservation reservation) {
            _reservationBook.AddReservation(reservation);
        }
    }
}

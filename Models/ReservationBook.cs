using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservoomMVVM.Exceptions;

namespace ReservoomMVVM.Models {
    public class ReservationBook {
        public readonly List<Reservation> _reservations;

        public ReservationBook() {
            _reservations = new List<Reservation>();
        }

        public IEnumerable<Reservation> GetReservationsForUser(string username) {
            return _reservations.Where(r => r.Username == username);
        }

        public void AddReservation(Reservation reservation) {
            foreach (Reservation existingReservation in _reservations) {
                if(existingReservation.Conflicts(reservation)) {
                    throw new ReservationConflictException(existingReservation, reservation);
                }
            }

            _reservations.Add(reservation);
        }
    }
}

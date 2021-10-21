using System;

namespace DoctorsWaitingRoom {
    class Patient {
        private int numberInQueue;
        private WaitingRoom waitingRoom;

        public Patient(WaitingRoom wr) {
            numberInQueue = wr.DrawNumber();
            waitingRoom = wr;
            waitingRoom.NumberChange += this.ReactToNumber;
        }

        public void ReactToNumber(int ticketNumber) {
            Console.WriteLine("Patient " + numberInQueue + " looks up");
            if (ticketNumber == numberInQueue) {
                Console.WriteLine("Patient with ticket number " + numberInQueue + " has entered the room.");
                waitingRoom.NumberChange -= this.ReactToNumber;
            }
        }
    }
}
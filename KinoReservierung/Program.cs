using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoReservierung
{
    class KinoReservierung
    {
        private readonly int ROOMS = 3;
        private readonly int ROWS = 10;
        private readonly int COLUMNS = 15;
        private readonly int[,,] seats;

        public KinoReservierung()
        {
            seats = new int[ROOMS, ROWS, COLUMNS];
            for(int i = 0; i < ROOMS; i++)
            {
                for (int j = 0; j < ROWS; j++)
                {
                    for (int k = 0; k < COLUMNS; k++)
                    {
                        seats[i, j, k] = 0;
                    }
                }
            }
        }

        private void MainMenu()
        {
            Console.WriteLine("Welcome, please enter a number.");
            Console.WriteLine("1 - Display Reservations");
            Console.WriteLine("2 - Input a Reservation");
            String input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    DisplayRoom(QuerryRoom());
                    break;
                case "2":
                    InputReservation();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        private void InputReservation()
        {
            Console.WriteLine("Please enter the room number (1-3)");
            Int64.TryParse(Console.ReadLine(), out long long_room);
            Console.WriteLine("Please enter the row number (1-10)");
            Int64.TryParse(Console.ReadLine(), out long long_row);
            Console.WriteLine("Please enter the collumn number (1-15)");
            Int64.TryParse(Console.ReadLine(), out long long_column);

            int room = (int)long_room - 1;
            int row = (int)long_row - 1;
            int column = (int)long_column - 1;

            if (   room >= 0 && room < ROOMS 
                && row >= 0 && row < ROWS
                && column >= 0 && column < COLUMNS) {

                if (seats[room, row, column] == 1) {
                    Console.WriteLine("Already Reserved");
                } else {
                    seats[room, row, column] = 1;
                }

            } else {
                Console.WriteLine("Invalid input");
            }
        }

        private int QuerryRoom()
        {
            Console.WriteLine("Please select a room (1-3)");
            Int64.TryParse(Console.ReadLine(), out long long_room);
            int room = (int)long_room - 1;
            return room;
        }

        private void DisplayRoom(int room)
        {
            for(int i = 0; i < ROWS; i++)
            {
                for(int j = 0; j < COLUMNS; j++)
                {
                    Console.Write("["+seats[room,i,j]+"]");
                }
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            KinoReservierung program = new KinoReservierung();
            do
            {
                program.MainMenu();
            } while (true);
        }
    }
}

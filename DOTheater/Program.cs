using System;
using static System.Console;

namespace DOTheater
{
    class Program
    {
        static void Main(string[] args)
        {
            double ticketPrice;
            double total = 0;
            string moreOrders = "y";
            const int NONVALID_SHOW = -1;

            while(moreOrders == "y")
            {
                Welcome();
                ticketPrice = Selection();

                while (ticketPrice == NONVALID_SHOW)
                {
                    if (ticketPrice == NONVALID_SHOW)
                    {
                        WriteLine("We do not have the show, selct one we do have");
                    }
                    ticketPrice = Selection();
                }


                total += CheckOut(ticketPrice);

                WriteLine("Do you want to order more tickets? (y/n)");
                moreOrders = ReadLine();
            }

            WriteLine("Your total order is {0:c}", total);
            
        }
        /*
         * Welcome Method
         * Writes out friendly message welcoming customer
         */
        private static void Welcome()
        {
            WriteLine(" Welcome to Oligarchy Theater!");
            WriteLine("What performercance are you interestead in seeing?");
            WriteLine("\t Romeo and Julias Ceacer");
            WriteLine("\t Nutcracker on Fire");
            WriteLine("\t The Producers");
        }

        /*
        * Selection Method
        * Gets customer selection and returns the ticket price
        * 
        * Output: double that is the cost of the ticket
        */
        private static double Selection()
        {
            double ticketPrice = -1;
            string[] shows = { "Romeo and Julias Ceacer", "Nutcracker on Fire", "The Producers", "Barney and Terminator on Ice" };
            double[] showCost = { 15, 25, 18, 5 };
            string select = ReadLine();

            int post = -1;

            for(int x = 0; x < shows.Length; ++x)
            {
                if (shows[x] == select)
                {
                    post = x;
                    x = shows.Length;
                }
            }

            if(post != -1)
            {
                ticketPrice = showCost[post];
            }


            return ticketPrice;
        }

        /*
        * Checkout Method
        * Gets customers final cost of ticket with optional selctions and tax
        * 
        * Output: double that is the cost of the ticket
        */
        private static double CheckOut(double ticketPrice)
        {
            WriteLine("Would you like rat free seating? (y/n)");
            string input = ReadLine();

            if (input == "y")
            {
                ticketPrice += 5;
            }

            WriteLine("Vallet Parking? (y/n)");
            input = ReadLine();
            if (input == "y")
            {
                ticketPrice += 3;
            }

            ticketPrice *= 1.07; //tax

            WriteLine("Cost with tax is {0:c}", ticketPrice);

            return ticketPrice;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define Starting Variables
            bool validinput = false;
            string input = "";
            DateTime dateValue;

            // Capture user input
            Console.WriteLine("What is your birthday? (Enter date in format MM/DD/YYYY: 04/19/1988)");
            input = Console.ReadLine();

            //Validate user input is in proper format, recapture if not
            while (validinput == false)
            {
                if (DateTime.TryParse(input, out dateValue))
                {
                    if (dateValue > DateTime.Now)
                    {
                        Console.WriteLine("Your date appears to be in the future. Please enter a date in the past using this format: MM/DD/YYYY: 04/19/1988");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        validinput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter the date in the proper format: MM/DD/YYYY: 04/19/1988)");
                    input = Console.ReadLine();
                }
            }

            //Refreshes calculation every second
            while (true)
            {
                DateTime today = DateTime.Now;
                DateTime bday = DateTime.Parse(input);

                //Get Difference in Days
                TimeSpan dbldays = today.Subtract(bday);
                double days = dbldays.Days;

                //Get Subset of Days in Year chunks
                double years = days / 365.25;
                double wholeyears = Math.Floor(years);
                int pubyears = Convert.ToInt32(wholeyears);

                //Get Subset of Days in Week chunks, excluding Years already accounted
                double daysnoyears = days % 365.25;
                double weeks = daysnoyears / 7;
                double wholeweeks = Math.Floor(weeks);
                int pubweeks = Convert.ToInt32(wholeweeks);

                //Get Subset of Days in Days, excluding Years and Weeks already accounted
                double remainingdays = days - ((wholeyears * 365.25) + (wholeweeks * 7));
                double wholedays = Math.Floor(remainingdays);
                int pubdays = Convert.ToInt32(wholedays);

                //Bonus - Get Hours, Minutes, Seconds, Milliseconds
                int pubhours = dbldays.Hours;
                int pubminutes = dbldays.Minutes;
                int pubseconds = dbldays.Seconds;
                int pubmilliseconds = dbldays.Milliseconds;

                //Console.WriteLine(dbldays);
                //Console.WriteLine("You are " + pubyears + " years, " + pubweeks + " weeks and " + pubdays+ " days old.");
                Console.WriteLine("You are " + pubyears + " years, " + pubweeks + " weeks, " + pubdays + " days, " + pubhours + " hours, " + pubminutes + " minutes, " + pubseconds + " seconds, and " + pubmilliseconds + " milliseconds old.");
                //Console.ReadLine();

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

            }
                            
        }
    }
}

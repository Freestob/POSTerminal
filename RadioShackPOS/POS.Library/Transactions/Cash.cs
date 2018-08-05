﻿using System;

namespace POS.Library
{
    public class Cash : ICashModel
    {
        
        // PROPS
        public float Tender { get; private set; }
        public float Change { get; private set; }
        public float Total { get; set; }
        Validator Validator = new Validator();
        // ctor
        public Cash()
        {
        }

        //handle making change for the customer
        //public string MakeChange(float total)
        //{
        //    var change = total - Tender;
        //    return change.ToString("c2");
        //}

        public void Transaction(float total)
        {
            // ask for and store user input
            Console.Write("Please enter a dollar amount('100.00'): ");
            var tender = Math.Round(float.Parse(Console.ReadLine()), 2);

            // validate user input to be in the form of 0.00 
            // the last two decimal places matter the most
            //if (!Validator.VailidCashFormat(Tender))
            //{
            //    // if invalid input call CashTransaction recursively
            //    Console.WriteLine("A valid dollar amount will end with two decimal places(100.00)");
            //    Transaction(total);
            //}
            // convert user input to float
            var change = tender - total;
            // display the users change
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format("Your change is {0}", Math.Round(change, 2)));
        }
    }
}
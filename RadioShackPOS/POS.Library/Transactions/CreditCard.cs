﻿using System;

namespace POS.Library
{
    public class CreditCard : ICreditCardModel
    {
        // PROPS
        public string CreditCardNumber { get; private set; }
        public string ExpirationDate { get; private set; }
        public string CVV { get; private set; }

        // Validator == Validator
        Validator Validator = new Validator();

        // ctor
        public CreditCard() { }

        // main methood for handling credit card transactions
        public void Transaction(float total)
        {
            // instantiate a new recpeit and order for the transaction
            var receipt = new Receipt();
            var receiptForOrder = new Order();
            // ask for cc number and validate it
            AskForCCNumber();
            // ask for expiration date - must not expire before DateTime.Now
            AskForExpDate();
            // ask for cvv and validate
            AskForCVV();
            Console.ForegroundColor = ConsoleColor.Green;
            // successful payment method
            Console.WriteLine($"Your purchase for {total.ToString("C")} has been completed!");
            Console.ForegroundColor = ConsoleColor.White;
            // display receipt and payment method
            receiptForOrder.GetReceiptDisplay();
            receipt.DisplayReceipt(this);

        }

        // method to recursively ask for cc number if it is invalid
        public string AskForCCNumber()
        {
            // ask for and store user input
            Console.Write("Please enter your credit card number ('1234123412341234 or 1234 1234 1234 1234'): ");
            CreditCardNumber = Console.ReadLine().Replace(" ", string.Empty).Trim();
            // if input is invalid display error
            // and call the method recursively
            if (!Validator.ValidateCCNumber(CreditCardNumber))
            {
                Console.WriteLine("Please enter a valid credit card number");
                AskForCCNumber();
            }
            return CreditCardNumber;
        }

        // method to recursively ask for cc expiration date if it is invalid
        public string AskForExpDate()
        {
            // ask for and store user input
            Console.Write("Please enter the expiration date (MM/YY): ");
            ExpirationDate = Console.ReadLine();

            if (!Validator.ValidateExpDate(ExpirationDate))
            {
                Console.WriteLine("That is not a valid date");
                AskForExpDate();
            }

            if (!Validator.CheckExpireDate(ExpirationDate))
            {
                Console.WriteLine("Your card has expired. Please enter a new date");
                AskForExpDate();
            }
            return ExpirationDate;
        }

        // method to recursively ask for cvv number if it is invalid
        public string AskForCVV()
        {
            // ask for and store user input
            Console.Write("Please enter the 3 digit code on the back of your card: ");
            CVV = Console.ReadLine();
            // if input is invalid display error
            // and call the method recursively

            if (!Validator.ValidateCVV(CVV))
            {
                Console.WriteLine("Please enter a valid CVV (3 digit code at the end of the signature line");
                AskForCVV();
            }
            return CVV;
        }
    }
}
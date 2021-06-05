using POS_System.Contracts;
using POS_System.Model;
using POS_System.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS_System.AppProgramHelper
{
    public static class ProgramComponents
    {
        /// <summary>
        /// Create a single instance of Cashier, It will depend on which country / culture the application is running
        /// </summary>
        /// <returns>A cashier object that implements ICashier</returns>
        public static ICashier CreateCashierObject()
        {
            const string es_MX = "es-MX";
            const string es_US = "en-US";
            //const string es-ES = "es-ES";

            /*Add the new code culture to perform the object creation
             *if you want to add a new country, you could add something like this: "es-ES" => new Cashier_ES(), into the switch 
             *the clas Cashier_ES does not exists yet.
             *To create it (Cashier_ES), go to Model -> POSbyCountries and add it.
             *It Must inherit cashier class and uses the cashier constructor
             *see an example in any of these classes (Cashier_MX, Cashier_US)
             */

            var currency = GetOrSetCurrency();

            ICashier cashier = currency switch
            {
                es_MX => new Cashier_MX(es_MX),
                es_US => new Cashier_US(es_US),
                //es-ES => new Cashier_ES(es-ES),
                _ => new Cashier_US(es_US),
            };
            return cashier;
        }
        /// <summary>
        /// This is the main menu that will interact with the user
        /// </summary>
        /// <param name="priceToPay"> price to pay reference</param>
        /// <param name="cashReceived">cash recived reference</param>
        /// <returns>cash Diference</returns>

        public static decimal MainMenu(ref decimal priceToPay, ref decimal cashReceived)
        {
             priceToPay = ReadInput("Price to pay: ");
            Console.WriteLine(Environment.NewLine);

             cashReceived = 0;
            decimal cashDiference;

            do
            {
                cashReceived += ReadInput("Payment: ");

                cashDiference = priceToPay - cashReceived;

                Console.WriteLine($"Cash recived: ${cashReceived}");

                if (cashDiference > 0)
                    Console.WriteLine($"Cash missing : ${cashDiference}");
                else
                    Console.WriteLine($"Cash to be returned: ${Math.Abs(cashDiference)}");

                Console.WriteLine(Environment.NewLine);

            } while (cashReceived < priceToPay);

            return cashDiference;
        }

        /// <summary>
        /// Set the global currency if is not already setted
        /// </summary>
        /// <returns>global currency code</returns>
        private static string GetOrSetCurrency()
        {
            ICurrencyService currencyService = new CurrencyService();
            var currency = currencyService.GetCurrency();

            if (string.IsNullOrEmpty(currency))
            {
                bool success = currencyService.SetCurrency();

                if (success)
                    return GetOrSetCurrency();
                else
                    return string.Empty;

            }

            return currency;
        }

        /// <summary>
        /// Reads user input and validates that it is a number greater than 0
        /// </summary>
        /// <param name="messageToPrint"> Custom message to be printed on console</param>
        /// <returns>a decimal value</returns>
        public static decimal ReadInput(string messageToPrint = "write a number greater than 0")
        {
            decimal valueOut;
            bool isNumber = false;

            do
            {
                Console.WriteLine(messageToPrint);
                var value = Console.ReadLine();
                decimal.TryParse(value, out valueOut);

                if (valueOut != 0)
                {
                    isNumber = true;
                }
                else
                {
                    Console.WriteLine("Only numbers greater than 0 are allowed");
                    Console.WriteLine(Environment.NewLine);
                }

            } while (isNumber == false);

            return valueOut;
        }

    }
}

using POS_System.Contracts;
using POS_System.Model;
using POS_System.Services;
using System;
using System.Linq;
using POS_System.AppProgramHelper;

namespace POS_System
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal priceToPay = 0, cashReceived = 0;

            var cashDiference = ProgramComponents.MainMenu(ref priceToPay, ref cashReceived);

            if (Math.Abs(cashDiference) > 0)
            {
                ICashier cashier = ProgramComponents.CreateCashierObject();

                var response = cashier.CalculateAmountOfChange(priceToPay,cashReceived);

                if (response.ErrorMessages.Count() > 0)
                {
                    Console.WriteLine("There were found the next errors: ");
                    foreach (var errorMesssage in response.ErrorMessages)
                    {
                        Console.WriteLine(errorMesssage);
                    }
                }
                else
                {
                    Console.WriteLine("Return the next bills and coins: ");
                    foreach (var item in response.BillsAndCoinsQuantity)
                    {
                        Console.WriteLine("$" + item.Key + " -> " + item.Value + Environment.NewLine);
                    }
                }
            }

            Console.WriteLine("Press any key to finish the program");
            Console.ReadKey();
        }
    }
}

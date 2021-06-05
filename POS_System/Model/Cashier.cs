using POS_System.Contracts;
using POS_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS_System.Model
{
    /// <summary>
    /// Derived this class to extend the support to many countries. Use this constructor with an array with all the denomination bills and coins of each country
    /// </summary>
    public class Cashier : ICashier
    {
       public decimal[] Denomination { get ; set ; }
        public string Currency { get ; set; }

        public Cashier(decimal[] denomination, string currency)
        {
            Denomination = denomination;
            Currency = currency;
        }
        
        public CashierResponse CalculateAmountOfChange(decimal priceToPay, decimal cashReceived)
        {
            CashierResponse casherResponse;
            Dictionary<decimal, int> BillsAndCoinsQuantity = new Dictionary<decimal, int>();
            
            List<string> errorMessages = ValidateInputs(priceToPay, cashReceived);

            if (errorMessages.Count == 0)
            {
                decimal changeToReturn = cashReceived - priceToPay;
                decimal cashTemp = changeToReturn;
                int quantity;

                for (int i = 0; i < Denomination.Length && cashTemp != 0; i++)
                {
                    if (cashTemp >= Denomination[i])
                    {
                        quantity = Convert.ToInt32((Math.Truncate(cashTemp / Denomination[i])));
                        BillsAndCoinsQuantity.Add(Denomination[i], quantity);
                        cashTemp %= Denomination[i];
                    }
                }

                casherResponse = new CashierResponse(priceToPay, cashReceived, changeToReturn, Currency, BillsAndCoinsQuantity, errorMessages);
            }
            else
            {
                casherResponse = new CashierResponse(priceToPay, cashReceived, 0, Currency, BillsAndCoinsQuantity, errorMessages);
            }

            return casherResponse;
        }

        private List<string> ValidateInputs(decimal priceToPay, decimal cashReceived)
        {
            List<string> errorMessages = new List<string>();

            if (priceToPay <= 0)
            {
                errorMessages.Add("price to pay must be greater than 0");
            }

            if (cashReceived <= 0)
            {
                errorMessages.Add("Cash received must be greater than 0");
            }

            if (priceToPay > cashReceived)
            {
                errorMessages.Add("Not enough cash to pay the total amount price");
            }

            return errorMessages;
        }
    }
}


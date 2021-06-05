using POS_System.Model;


namespace POS_System.Contracts
{
    public interface ICashier
    {
        /// <summary>
        /// Property to save a decimal array to save all the bills and coins denominations
        /// </summary>
        public decimal[] Denomination { get; set; }

        /// <summary>
        /// Property to save the currency culture code
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Calculate the number of bills and coins to be returned
        /// </summary>
        /// <param name="priceToPay"> total amount to pay</param>
        /// <param name="cashReceived">total cash recived by the user</param>
        /// <returns>A CasherResponse object</returns>
        CashierResponse CalculateAmountOfChange(decimal priceToPay, decimal cashReceived);
    }
}

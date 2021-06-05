using Microsoft.VisualStudio.TestTools.UnitTesting;
using POS_System.Contracts;
using POS_System.Model;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class CashierTest
    {
        [TestMethod]
        public void Cashier_CalculateAmountOfChange_FailsIfPriceIsGreaterThanCashReceived()
        {
            ICashier cashier = new Cashier_MX("es-MX");

            var response = cashier.CalculateAmountOfChange(25, 20);

            Assert.IsNotNull(response.ErrorMessages.FirstOrDefault(x => x == "Not enough cash to pay the total amount price"));
        }

        [TestMethod]
        public void Cashier_CalculateAmountOfChange_FailsIfCashReceivedIsLessToOne()
        {
            ICashier cashier = new Cashier_MX("es-MX");

            var response = cashier.CalculateAmountOfChange(25, 0);

            Assert.IsNotNull(response.ErrorMessages.FirstOrDefault(x => x == "Cash received must be greater than 0"));
        }

        [TestMethod]
        public void Cashier_CalculateAmountOfChange_FailsIfPriceToPayIsLessToOne()
        {
            ICashier cashier = new Cashier_MX("es-MX");

            var response = cashier.CalculateAmountOfChange(0, 1);

            Assert.IsNotNull(response.ErrorMessages.FirstOrDefault(x => x == "price to pay must be greater than 0"));
        }

        [TestMethod]
        public void Cashier_CalculateAmountOfChange_SuccessIfDoNotGetAnyErrorMessage()
        {
            ICashier cashier = new Cashier_MX("es-MX");

            var response = cashier.CalculateAmountOfChange(25, 35);

            Assert.IsTrue(response.ErrorMessages.Count() == 0);
        }
    }
}

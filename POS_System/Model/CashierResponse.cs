using System.Collections.Generic;

namespace POS_System.Model
{
    public class CashierResponse
    {
        private decimal _PriceToPay;
        private decimal _CashReceived;
        private decimal _AmountOfChange;
        private string _Currency;
        private IEnumerable<KeyValuePair<decimal, int>> _BillsAndCoinsQuantity;
        private IEnumerable<string> _ErrorMessages;

        public CashierResponse(decimal priceToPay, decimal cashReceived,  decimal amountOfChange,string currency, IEnumerable<KeyValuePair<decimal, int>> billsAndCoinsQuantity, IEnumerable<string>  errorMessages)
        {
            _PriceToPay = priceToPay;
            _CashReceived = cashReceived;
            _AmountOfChange = amountOfChange;
            _Currency = currency;
            _BillsAndCoinsQuantity = billsAndCoinsQuantity;
            ErrorMessages = errorMessages;
        }

        public decimal PriceToPay { get => _PriceToPay;  }
        public decimal CashReceived { get => _CashReceived;  }
        public decimal AmountOfChange { get => _AmountOfChange;  }
        public string Currency { get => _Currency; }
        public IEnumerable<KeyValuePair<decimal, int>> BillsAndCoinsQuantity { get => _BillsAndCoinsQuantity;  }
        public IEnumerable<string> ErrorMessages { get => _ErrorMessages; set => _ErrorMessages = value; }
    }
}

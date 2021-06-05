using POS_System.Contracts;
using POS_System.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace POS_System.Services
{
    public class CurrencyService : ICurrencyService
    {
        private static string baseDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}/Currency";
        private static string currencyFilePath = $"{baseDirectory}/currency.txt";

        private string _currency;
        public string Currency { get => _currency; set => _currency = value; }

        /// <summary>
        /// Get Global Currency locate in app base directory
        /// </summary>
        /// <returns></returns>
        public string GetCurrency()
        {
            if (File.Exists(currencyFilePath))
                Currency = File.ReadAllText(currencyFilePath);
            else
                Currency = string.Empty;
            
            return Currency;
        }

        /// <summary>
        /// Set Global Currency locate in app base directory
        /// </summary>
        /// <returns></returns>

        public bool SetCurrency()
        {
            bool success = false;
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

            string currentCulture = cultureInfo.Name;
            using (FileStream fs = File.Create(currencyFilePath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(currentCulture);
                fs.Write(info, 0, info.Length);

                success = true;
            }

            Currency = currentCulture;

            return success;
        }
    }
}

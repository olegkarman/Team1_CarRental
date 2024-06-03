using System;
using System.Collections.Generic;

namespace CarRental.Models
{
    internal class Deal
    {
        internal string customerId { get; set; }
        internal string carId { get; set; }
        internal float price { get; set; }

        private string _dealType;
        internal string dealType
        {
            get { return _dealType; }
            set
            {
                if (value == "purchase" || value == "rental")
                {
                    _dealType = value;
                }
                else
                {
                    throw new ArgumentException("Wrong value! (\"purchase\" or \"rental\" only)");
                }
            }
        }

        internal Deal(string customerId, string carId, string type, float price)
        {
            this.dealType = type;
            this.price = price;
            this.carId = carId;
            this.customerId = customerId;

            /*Dictionary<int, Tuple<string, string, string, float, DateTime>> dealInfo =
                new Dictionary<int, Tuple<string, string, string, float, DateTime>>();

            Random rnd = new Random();
            int dealId = rnd.Next(0, 99999);

            dealInfo[dealId] = new Tuple<string, string, string, float, DateTime>(this.customerId, this.carId, this.dealType, this.price, DateTime.Now);

            DealManager dealManager = new DealManager();
            dealManager.SaveDealInfo(dealInfo);*/
        }

        public override string ToString()
        {
            return $"The customer {customerId} has {dealType} a car VIN code is {carId} and the price is {price}";
        }
    }
}

using System;
using System.Collections.Generic;

namespace CarRental.Models
{
    internal class Deal
    {
        internal int customerId { get; set; }
        internal int carId { get; set; }
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

        internal void CreateDeal(int customerId, int carId, string type, float price)
        {
            this.dealType = type;
            this.price = price;
            this.carId = carId;
            this.customerId = customerId;

            Dictionary<int, Tuple<int, int, string, float, DateTime>> dealInfo =
                new Dictionary<int, Tuple<int, int, string, float, DateTime>>();

            Random rnd = new Random();
            int dealId = rnd.Next(0, 99999);

            dealInfo[dealId] = new Tuple<int, int, string, float, DateTime>(this.customerId, this.carId, this.dealType, this.price, DateTime.Now);

            DealManager dealManager = new DealManager();
            dealManager.SaveDealInfo(dealInfo);
        }

        internal string GetAllDealsJson()
        {
            DealManager dealManager = new DealManager();
            return dealManager.GetDealInfoJson();
        }

        internal
            Dictionary<int, Tuple<int, int, string, float, DateTime>>
            GetAllDealsDict()
        {
            DealManager dealManager = new DealManager();
            return dealManager.GetDealInfoDict();
        }
    }
}

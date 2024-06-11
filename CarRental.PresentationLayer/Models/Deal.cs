namespace CarRental.Data.Models
{
    public class Deal
    {
        public string Name { get; set; }
        public string customerId { get; set; }
        public string carId { get; set; }
        public float price { get; set; }

        private string _dealType;
        public string dealType
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

        public Deal(string customerId, string carId, string type, float price)
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

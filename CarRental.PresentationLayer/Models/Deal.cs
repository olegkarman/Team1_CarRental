namespace CarRental.Data.Models
{
    public class Deal
    {
        public string Name { get; set; }
        public string CustomerId { get; set; }
        public string CarId { get; set; }
        public float Price { get; set; }

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

        public Deal(string CustomerId, string CarId, string type, float Price)
        {
            this.dealType = type;
            this.Price = Price;
            this.CarId = CarId;
            this.CustomerId = CustomerId;

            /*Dictionary<int, Tuple<string, string, string, float, DateTime>> dealInfo =
                new Dictionary<int, Tuple<string, string, string, float, DateTime>>();

            Random rnd = new Random();
            int dealId = rnd.Next(0, 99999);

            dealInfo[dealId] = new Tuple<string, string, string, float, DateTime>(this.CustomerId, this.CarId, this.dealType, this.Price, DateTime.Now);

            DealManager dealManager = new DealManager();
            dealManager.SaveDealInfo(dealInfo);*/
        }

        public override string ToString()
        {
            return $"The customer {CustomerId} has {dealType} a car VIN code is {CarId} and the Price is {Price}";
        }
    }
}

namespace CarRental.Data.Models
{
    public record class Deal
    {
        // PROPERTIES

        //public Guid Id { get; init; }
        public string Name { get; init; }
        public string CustomerId { get; init; }
        public string VinCode { get; init; }
        public Guid CarId { get; init; }
        public float Price { get; init; }

        private string _dealType;

        // FOR WHAT A PURPOSE IT? MAYBE ENUM INSTEAD? WELL, NEVERMIND...
        public string DealType
        {
            get { return _dealType; }
            init
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

        // CONSTRUCTORS

        public Deal()
        {
            
        }

        public Deal(string CustomerId, Guid CarId, string type, float Price)
        {
            this.DealType = type;
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

        // IN THE RECORD-CLASS IT IS UNECCESSARY.
        public override string ToString()
        {
            return $"The customer {CustomerId} has {DealType} a car VIN code is {VinCode} and the Price is {Price}";
        }
    }
}

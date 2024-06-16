using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Managers
{
    public class MechanicManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";

        // PROPERTIES

        public List<Mechanic> Mechanics { get; set; }

        // CONSTRUCTORS

        public MechanicManager()
        {
            this.Mechanics = new List<Mechanic>();
        }

        // METHODS

        public Mechanic CreateNewMechanic()
        {
            Mechanic mechanic = new Mechanic
            {
                
            }

            return mechanic;
        }
    }
}

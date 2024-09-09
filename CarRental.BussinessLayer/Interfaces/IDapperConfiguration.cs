using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IDapperConfiguration
    {
        public void ConfigureGuidToStringMapping();
        public void SetCustomMappingForEntities();
    }
}

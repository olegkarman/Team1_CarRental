using CarRental.Data.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces;
public interface IInspectionsManager
{
    void AddInspection(Inspection inspection);
    void RemoveInspection(Inspection inspection);
    Inspection? GetInspection(Inspection inspection);
    List<Inspection> GetSuccessfulInspections();
    List<string> InspectionInfoList();
}

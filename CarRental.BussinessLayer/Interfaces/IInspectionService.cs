using CarRental.Data.Enums;
using CarRental.Data.Inspection;
using CarRental.Data.Models;
using CarRental.Data.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces;
public interface IInspectionService
{
    Inspection CreateInspection(Inspector inspector, Car car, InspectionStatusType result);
    bool IsInspectionSuccessfully(Inspection inspection);
    string GetInfo(Inspection inspection);
}

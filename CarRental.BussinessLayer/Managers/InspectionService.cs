using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Enums;
using CarRental.Data.Models.Checkup;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Managers;
public class InspectionService: IInspectionService
{
    public Inspection CreateInspection(Inspector inspector, Car car, InspectionStatusType result)
    {
        return new Inspection(inspector, car, result);
    }
    public bool IsInspectionSuccessfully(Inspection inspection)
    {
        return (inspection.InspectionId == inspection.InspectionId) && (inspection.Result == InspectionStatusType.Successfully);
    }

    public string GetInfo(Inspection inspection)
    {
        return $"Inspection Number: {inspection.InspectionId}\n" +
            $"Inspector Name: {inspection.InspectorName}\n" +
            $"Car ID: {inspection.CarId}\n" +
            $"Inspection Date: {inspection.InspectionDate.Value.ToShortDateString()}\n" +
            $"Result: {inspection.Result}\n";
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Car;

namespace CarRental.Records;
public record AutoSupplier
{
    public string SupplierId { get; init; }
    public string CompanyName { get; init; }
    public string ContactName { get; init; }
    public string ContactPhone { get; init; }
    public string Address { get; init; }
}

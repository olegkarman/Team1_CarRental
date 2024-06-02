using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.Records;
public record UserInSystem(
    User UserData,
    bool isCusomer
) {}

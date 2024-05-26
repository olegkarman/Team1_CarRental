using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal record class BrandModelsNamesDataSheet
{
    // PROPERTIES

    internal string[] BrandNamesData { get; init; }
    internal string[] ModelNamesData { get; init; }

    // CONSTRUCTORS

    internal BrandModelsNamesDataSheet()
    {
        this.BrandNamesData = ["Zaporozhets", "Peugeot", "Volkswagen", "Nissan", "Gyguli", "Jeep"];
        this.ModelNamesData = [
        // 0 — ZAP [0, 2]
        "ZAZ-966V", "ZAZ-965", "ZAZ-968",

        // 1 — PEG [3, 13]
        "Peugeot-204", "Peugeot-J7", "Peugeot-305", "Peugeot-J9", "Peugeot-P4", "Peugeot-406", "Peugeot-6007", "Peugeot-107", "Peugeot-908", "Bipper", "Peugeot-108",

        // 2 — VOL [14, 24]
        "Golf", "Passat", "Polo", "Jetta", "Multivan", "Bora", "Touareg", "Touran", "Caddy Life", "Lamando", "ID.3",

        // 3 — NIS [25, 35]
        "Patrol", "Skyline", "GT-R", "Serena", "Altima", "V-Drive", "Elgrand", "Sylphy", "X-Trail", "Murano", "Qashqai",

        // 4 — GYG [36, 42]
        "VAZ-2101", "VAZ-2102", "VAZ-2103", "VAZ-2106", "VAZ-2105", "VAZ-2107", "VAZ-2104",

        // 5 — JEP [43, 52]
        "Dakar", "Rubicon", "Malibu", "Wide-Trac", "Cherokee", "Creep", "Cowboy", "Freedom", "Wrangler", "Ecco"
        ];
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Models.Car;

public record class BrandModelsNamesDataSheet
{
    // THE PURPOSE OF THE CLASS:
    // // IT IS A MAIN DATA HOLDER CLASS.

    // PROPERTIES

    internal string[] BrandNamesData { get; init; }
    internal string[] ModelNamesData { get; init; }
    internal Dictionary<string, int[]> ModelPatternDataDictionary { get; init; }

    // CONSTRUCTORS

    internal BrandModelsNamesDataSheet()
    {
        this.BrandNamesData = ["Zaporozhets", "Peugeot", "Volkswagen", "Nissan", "Gyguli", "Jeep"];
        this.ModelNamesData =
        [
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

        this.ModelPatternDataDictionary = new Dictionary<string, int[]>
        {
            {
                // ZAZ

                "ZAZ-966V", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 85, 85, /*PRICE*/ 5500, 5500, /*MAX FUEL*/ 70, 70, /*CURRENT FUEL*/ 70, 70, /*SPPED COEF*/ 2, 2, /*AVG FUEL CONS*/ 1, 1, /*FUEL ENGI*/ 11, 11, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 10, 10, /*TYPE TRANSM*/ 10, 10, /*SPEED COUNT*/ 2, 2, /*COLOR INTE*/ 118, 118, /*MATERIAL INTE*/ 10, 10, /*MATERIAL WHEEL*/ 10, 10, /*SIZE WHEEL*/ 8, 8, /*TIRE*/ 10, 10, /*COLOUR LIGHTS*/ 30, 30, /*POWER LIGHTS*/ 10, 10, /*PITCH*/ 11, 11}
            },

            {
                "ZAZ-965", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 85, 85, /*PRICE*/ 5500, 5500, /*MAX FUEL*/ 70, 70, /*CURRENT FUEL*/ 70, 70, /*SPPED COEF*/ 2, 2, /*AVG FUEL CONS*/ 1, 1, /*FUEL ENGI*/ 11, 11, /*TYPE ENGI*/ 12, 12, /*POW ENGI*/ 10, 10, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 2, 2, /*COLOR INTE*/ 118, 118, /*MATERIAL INTE*/ 10, 10, /*MATERIAL WHEEL*/ 10, 10, /*SIZE WHEEL*/ 8, 8, /*TIRE*/ 10, 10, /*COLOUR LIGHTS*/ 30, 30, /*POWER LIGHTS*/ 10, 10, /*PITCH*/ 11, 11}
            },

            {
                "ZAZ-968", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 85, 85, /*PRICE*/ 5500, 5500, /*MAX FUEL*/ 100, 100, /*CURRENT FUEL*/ 100, 100, /*SPPED COEF*/ 2, 2, /*AVG FUEL CONS*/ 1, 1, /*FUEL ENGI*/ 11, 11, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 10, 10, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 2, 2, /*COLOR INTE*/ 119, 119, /*MATERIAL INTE*/ 10, 10, /*MATERIAL WHEEL*/ 10, 10, /*SIZE WHEEL*/ 8, 8, /*TIRE*/ 11, 11, /*COLOUR LIGHTS*/ 30, 30, /*POWER LIGHTS*/ 10, 10, /*PITCH*/ 11, 11}
            },

            // PEG

            {
                "Peugeot-204", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 85, 85, /*PRICE*/ 1000, 1000, /*MAX FUEL*/ 100, 100, /*CURRENT FUEL*/ 100, 100, /*SPPED COEF*/ 3, 3, /*AVG FUEL CONS*/ 3, 3, /*FUEL ENGI*/ 11, 11, /*TYPE ENGI*/ 12, 12, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 2, 2, /*COLOR INTE*/ 119, 119, /*MATERIAL INTE*/ 10, 10, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 10, 10, /*TIRE*/ 13, 13, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 11, 11}
            },

            {
                "Peugeot-J7", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 85, 85, /*PRICE*/ 10000, 10000, /*MAX FUEL*/ 120, 120, /*CURRENT FUEL*/ 120, 120, /*SPPED COEF*/ 4, 4, /*AVG FUEL CONS*/ 3, 3, /*FUEL ENGI*/ 10, 10, /*TYPE ENGI*/ 12, 12, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 2, 2, /*COLOR INTE*/ 119, 119, /*MATERIAL INTE*/ 10, 10, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 10, 10, /*TIRE*/ 13, 13, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 11, 11}
            },

            {
                "Peugeot-305", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 85, 85, /*PRICE*/ 12000, 12000, /*MAX FUEL*/ 120, 120, /*CURRENT FUEL*/ 120, 120, /*SPPED COEF*/ 4, 4, /*AVG FUEL CONS*/ 3, 3, /*FUEL ENGI*/ 13, 13, /*TYPE ENGI*/ 13, 13, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 2, 2, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 10, 10, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 10, 10, /*TIRE*/ 13, 13, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 11, 11}
            },

            {
                "Peugeot-J9", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 85, 85, /*PRICE*/ 15000, 15000, /*MAX FUEL*/ 120, 120, /*CURRENT FUEL*/ 120, 120, /*SPPED COEF*/ 4, 4, /*AVG FUEL CONS*/ 4, 4, /*FUEL ENGI*/ 13, 13, /*TYPE ENGI*/ 12, 12, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 2, 2, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 10, 10, /*TIRE*/ 13, 13, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 11, 11}
            },

            {
                "Peugeot-P4", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 85, 85, /*PRICE*/ 14000, 14000, /*MAX FUEL*/ 120, 120, /*CURRENT FUEL*/ 120, 120, /*SPPED COEF*/ 4, 4, /*AVG FUEL CONS*/ 4, 4, /*FUEL ENGI*/ 12, 12, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 10, 10, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 10, 10, /*TIRE*/ 13, 13, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 11, 11}
            },

            {
                "Peugeot-406", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 85, 85, /*PRICE*/ 20000, 20000, /*MAX FUEL*/ 120, 120, /*CURRENT FUEL*/ 120, 120, /*SPPED COEF*/ 4, 4, /*AVG FUEL CONS*/ 4, 4, /*FUEL ENGI*/ 13, 13, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 10, 10, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 10, 10, /*TIRE*/ 13, 13, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 11, 11}
            },

            {
                "Peugeot-6007", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 85, 85, /*PRICE*/ 30000, 30000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 4, 4, /*AVG FUEL CONS*/ 5, 5, /*FUEL ENGI*/ 13, 13, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 10, 10, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 34, 34, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 11, 11}
            },

            {
                "Peugeot-107", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 100, 100, /*PRICE*/ 40000, 40000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 5, 5, /*AVG FUEL CONS*/ 6, 6, /*FUEL ENGI*/ 13, 13, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 14, 14, /*COLOUR LIGHTS*/ 34, 34, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Peugeot-908", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 124, 124, /*PRICE*/ 66000, 66000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 5, 5, /*AVG FUEL CONS*/ 6, 6, /*FUEL ENGI*/ 13, 13, /*TYPE ENGI*/ 13, 13, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 14, 14, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Bipper", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 124, 124, /*PRICE*/ 100000, 100000, /*MAX FUEL*/ 300, 300, /*CURRENT FUEL*/ 300, 300, /*SPPED COEF*/ 5, 5, /*AVG FUEL CONS*/ 6, 6, /*FUEL ENGI*/ 13, 13, /*TYPE ENGI*/ 13, 13, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 121, 121, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 14, 14, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Peugeot-108", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 131, 131, /*PRICE*/ 150000, 150000, /*MAX FUEL*/ 300, 300, /*CURRENT FUEL*/ 300, 300, /*SPPED COEF*/ 7, 7, /*AVG FUEL CONS*/ 7, 7, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 121, 121, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 14, 14, /*COLOUR LIGHTS*/ 36, 36, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            // VOL

            {
                "Golf", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 140, 140, /*PRICE*/ 17000, 17000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 6, 6, /*AVG FUEL CONS*/ 7, 7, /*FUEL ENGI*/ 20, 20, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 121, 121, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 14, 14, /*COLOUR LIGHTS*/ 33, 33, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Passat", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 139, 139, /*PRICE*/ 25000, 25000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 6, 6, /*AVG FUEL CONS*/ 7, 7, /*FUEL ENGI*/ 20, 20, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 14, 14, /*COLOUR LIGHTS*/ 33, 33, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Polo", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 138, 138, /*PRICE*/ 29000, 29000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 6, 6, /*AVG FUEL CONS*/ 10, 10, /*FUEL ENGI*/ 20, 20, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 12, 12, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 14, 14, /*COLOUR LIGHTS*/ 33, 33, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Jetta", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 138, 138, /*PRICE*/ 30000, 30000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 6, 6, /*AVG FUEL CONS*/ 10, 10, /*FUEL ENGI*/ 19, 19, /*TYPE ENGI*/ 11, 11, /*POW ENGI*/ 13, 13, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 15, 15, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Multivan", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 138, 138, /*PRICE*/ 50000, 50000, /*MAX FUEL*/ 600, 600, /*CURRENT FUEL*/ 600, 600, /*SPPED COEF*/ 1, 1, /*AVG FUEL CONS*/ 10, 10, /*FUEL ENGI*/ 17, 17, /*TYPE ENGI*/ 12, 12, /*POW ENGI*/ 14, 14, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 120, 120, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 15, 15, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Bora", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 138, 138, /*PRICE*/ 55000, 55000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 1, 1, /*AVG FUEL CONS*/ 10, 10, /*FUEL ENGI*/ 18, 18, /*TYPE ENGI*/ 12, 12, /*POW ENGI*/ 15, 15, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 5, 5, /*COLOR INTE*/ 121, 121, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 15, 15, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Touareg", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 138, 138, /*PRICE*/ 105000, 105000, /*MAX FUEL*/ 220, 220, /*CURRENT FUEL*/ 220, 220, /*SPPED COEF*/ 8, 8, /*AVG FUEL CONS*/ 12, 12, /*FUEL ENGI*/ 21, 21, /*TYPE ENGI*/ 12, 12, /*POW ENGI*/ 17, 17, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 5, 5, /*COLOR INTE*/ 117, 117, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 15, 15, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Touran", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 138, 138, /*PRICE*/ 130000, 130000, /*MAX FUEL*/ 220, 220, /*CURRENT FUEL*/ 220, 220, /*SPPED COEF*/ 9, 9, /*AVG FUEL CONS*/ 12, 12, /*FUEL ENGI*/ 21, 21, /*TYPE ENGI*/ 12, 12, /*POW ENGI*/ 17, 17, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 117, 117, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 15, 15, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Caddy Life", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 138, 138, /*PRICE*/ 170000, 170000, /*MAX FUEL*/ 220, 220, /*CURRENT FUEL*/ 220, 220, /*SPPED COEF*/ 10, 10, /*AVG FUEL CONS*/ 12, 12, /*FUEL ENGI*/ 20, 20, /*TYPE ENGI*/ 12, 12, /*POW ENGI*/ 17, 17, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 117, 117, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 15, 15, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Lamando", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 138, 138, /*PRICE*/ 180000, 180000, /*MAX FUEL*/ 220, 220, /*CURRENT FUEL*/ 220, 220, /*SPPED COEF*/ 10, 10, /*AVG FUEL CONS*/ 12, 12, /*FUEL ENGI*/ 20, 20, /*TYPE ENGI*/ 18, 18, /*POW ENGI*/ 17, 17, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 115, 115, /*MATERIAL INTE*/ 12, 12, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "ID.3", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 138, 138, /*PRICE*/ 250000, 250000, /*MAX FUEL*/ 220, 220, /*CURRENT FUEL*/ 220, 220, /*SPPED COEF*/ 10, 10, /*AVG FUEL CONS*/ 1, 1, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 18, 18, /*POW ENGI*/ 17, 17, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 115, 115, /*MATERIAL INTE*/ 12, 12, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 16, 16, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            // NIS

             {
                "Patrol", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 138, 138, /*PRICE*/ 24000, 24000, /*MAX FUEL*/ 220, 220, /*CURRENT FUEL*/ 220, 220, /*SPPED COEF*/ 10, 10, /*AVG FUEL CONS*/ 5, 5, /*FUEL ENGI*/ 15, 15, /*TYPE ENGI*/ 17, 17, /*POW ENGI*/ 14, 14, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 115, 115, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 14, 14, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 33, 33, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 12, 12}
            },

            {
                "Skyline", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 133, 133, /*PRICE*/ 40000, 40000, /*MAX FUEL*/ 220, 220, /*CURRENT FUEL*/ 220, 220, /*SPPED COEF*/ 17, 17, /*AVG FUEL CONS*/ 6, 6, /*FUEL ENGI*/ 15, 15, /*TYPE ENGI*/ 17, 17, /*POW ENGI*/ 14, 14, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 115, 115, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 14, 14, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 33, 33, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 12, 12}
            },

            {
                "GT-R", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 133, 133, /*PRICE*/ 52000, 52000, /*MAX FUEL*/ 220, 220, /*CURRENT FUEL*/ 220, 220, /*SPPED COEF*/ 20, 20, /*AVG FUEL CONS*/ 6, 6, /*FUEL ENGI*/ 15, 15, /*TYPE ENGI*/ 17, 17, /*POW ENGI*/ 15, 15, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 114, 114, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 14, 14, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 33, 33, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 12, 12}
            },

            {
                "Serena", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 60000, 60000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 16, 16, /*AVG FUEL CONS*/ 7, 7, /*FUEL ENGI*/ 17, 17, /*TYPE ENGI*/ 17, 17, /*POW ENGI*/ 15, 15, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 114, 114, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 14, 14, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 33, 33, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 12, 12}
            },

            {
                "Altima", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 65000, 65000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 16, 16, /*AVG FUEL CONS*/ 5, 5, /*FUEL ENGI*/ 17, 17, /*TYPE ENGI*/ 17, 17, /*POW ENGI*/ 15, 15, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 5, 5, /*COLOR INTE*/ 116, 116, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 14, 14, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 33, 33, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 12, 12}
            },

            {
                "V-Drive", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 150000, 150000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 20, 20, /*AVG FUEL CONS*/ 5, 5, /*FUEL ENGI*/ 17, 17, /*TYPE ENGI*/ 17, 17, /*POW ENGI*/ 15, 15, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 116, 116, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 17, 17, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 33, 33, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 12, 12}
            },

            {
                "Elgrand", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 140000, 140000, /*MAX FUEL*/ 300, 300, /*CURRENT FUEL*/ 300, 300, /*SPPED COEF*/ 10, 10, /*AVG FUEL CONS*/ 5, 5, /*FUEL ENGI*/ 17, 17, /*TYPE ENGI*/ 17, 17, /*POW ENGI*/ 15, 15, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 118, 118, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 17, 17, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 31, 31, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 12, 12}
            },

            {
                "Sylphy", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 170000, 170000, /*MAX FUEL*/ 150, 150, /*CURRENT FUEL*/ 150, 150, /*SPPED COEF*/ 20, 20, /*AVG FUEL CONS*/ 7, 7, /*FUEL ENGI*/ 16, 16, /*TYPE ENGI*/ 14, 14, /*POW ENGI*/ 15, 15, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 118, 118, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 15, 15, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 30, 30, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 12, 12}
            },

            {
                "X-Trail", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 135000, 135000, /*MAX FUEL*/ 150, 150, /*CURRENT FUEL*/ 150, 150, /*SPPED COEF*/ 20, 20, /*AVG FUEL CONS*/ 7, 7, /*FUEL ENGI*/ 16, 16, /*TYPE ENGI*/ 12, 12, /*POW ENGI*/ 16, 16, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 118, 118, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 15, 15, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 11, 11, /*PITCH*/ 11, 11}
            },

            {
                "Murano", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 200000, 200000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 19, 19, /*AVG FUEL CONS*/ 7, 7, /*FUEL ENGI*/ 16, 16, /*TYPE ENGI*/ 17, 17, /*POW ENGI*/ 16, 16, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 118, 118, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 15, 15, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 37, 37, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 12, 12}
            },

            {
                "Qashqai", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 210000, 210000, /*MAX FUEL*/ 270, 270, /*CURRENT FUEL*/ 270, 270, /*SPPED COEF*/ 19, 19, /*AVG FUEL CONS*/ 8, 8, /*FUEL ENGI*/ 17, 17, /*TYPE ENGI*/ 17, 17, /*POW ENGI*/ 16, 16, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 7, 7, /*COLOR INTE*/ 116, 116, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 15, 15, /*TIRE*/ 12, 12, /*COLOUR LIGHTS*/ 37, 37, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 12, 12}
            },

            // GYG

            {
                "VAZ-2101", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 130, 130, /*PRICE*/ 5000, 5000, /*MAX FUEL*/ 150, 150, /*CURRENT FUEL*/ 150, 150, /*SPPED COEF*/ 5, 5, /*AVG FUEL CONS*/ 8, 8, /*FUEL ENGI*/ 12, 12, /*TYPE ENGI*/ 13, 13, /*POW ENGI*/ 10, 10, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 113, 113, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 13, 13, /*TIRE*/ 13, 13, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "VAZ-2102", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 131, 131, /*PRICE*/ 6000, 6000, /*MAX FUEL*/ 160, 160, /*CURRENT FUEL*/ 160, 160, /*SPPED COEF*/ 4, 4, /*AVG FUEL CONS*/ 8, 8, /*FUEL ENGI*/ 11, 11, /*TYPE ENGI*/ 14, 14, /*POW ENGI*/ 9, 9, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 113, 113, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 12, 12, /*SIZE WHEEL*/ 13, 13, /*TIRE*/ 13, 13, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "VAZ-2103", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 131, 131, /*PRICE*/ 8000, 8000, /*MAX FUEL*/ 160, 160, /*CURRENT FUEL*/ 160, 160, /*SPPED COEF*/ 6, 6, /*AVG FUEL CONS*/ 9, 9, /*FUEL ENGI*/ 12, 12, /*TYPE ENGI*/ 15, 15, /*POW ENGI*/ 9, 9, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 4, 4, /*COLOR INTE*/ 113, 113, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 13, 13, /*TIRE*/ 13, 13, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "VAZ-2106", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 131, 131, /*PRICE*/ 10000, 10000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 6, 6, /*AVG FUEL CONS*/ 9, 9, /*FUEL ENGI*/ 12, 12, /*TYPE ENGI*/ 16, 16, /*POW ENGI*/ 9, 9, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 112, 112, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 13, 13, /*TIRE*/ 14, 14, /*COLOUR LIGHTS*/ 36, 36, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "VAZ-2105", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 130, 130, /*PRICE*/ 12000, 12000, /*MAX FUEL*/ 200, 200, /*CURRENT FUEL*/ 200, 200, /*SPPED COEF*/ 6, 6, /*AVG FUEL CONS*/ 9, 9, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 16, 16, /*POW ENGI*/ 9, 9, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 113, 113, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 13, 13, /*TIRE*/ 14, 14, /*COLOUR LIGHTS*/ 36, 36, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "VAZ-2107", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 130, 130, /*PRICE*/ 16000, 16000, /*MAX FUEL*/ 210, 210, /*CURRENT FUEL*/ 210, 210, /*SPPED COEF*/ 6, 6, /*AVG FUEL CONS*/ 10, 10, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 15, 15, /*POW ENGI*/ 10, 10, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 117, 117, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 13, 13, /*TIRE*/ 14, 14, /*COLOUR LIGHTS*/ 36, 36, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "VAZ-2104", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 130, 130, /*PRICE*/ 21000, 21000, /*MAX FUEL*/ 210, 210, /*CURRENT FUEL*/ 210, 210, /*SPPED COEF*/ 6, 6, /*AVG FUEL CONS*/ 10, 10, /*FUEL ENGI*/ 12, 12, /*TYPE ENGI*/ 16, 16, /*POW ENGI*/ 11, 11, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 117, 117, /*MATERIAL INTE*/ 11, 11, /*MATERIAL WHEEL*/ 11, 11, /*SIZE WHEEL*/ 13, 13, /*TIRE*/ 15, 15, /*COLOUR LIGHTS*/ 36, 36, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            // JEP

            {
                "Dakar", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 130, 130, /*PRICE*/ 61000, 61000, /*MAX FUEL*/ 320, 320, /*CURRENT FUEL*/ 320, 320, /*SPPED COEF*/ 5, 5, /*AVG FUEL CONS*/ 15, 15, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 13, 13, /*POW ENGI*/ 20, 20, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 116, 116, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 18, 18, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

             {
                "Rubicon", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 130, 130, /*PRICE*/ 74000, 74000, /*MAX FUEL*/ 310, 310, /*CURRENT FUEL*/ 310, 310, /*SPPED COEF*/ 6, 6, /*AVG FUEL CONS*/ 15, 15, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 13, 13, /*POW ENGI*/ 21, 21, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 115, 115, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 18, 18, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 34, 34, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Malibu", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 130, 130, /*PRICE*/ 78000, 78000, /*MAX FUEL*/ 310, 310, /*CURRENT FUEL*/ 310, 310, /*SPPED COEF*/ 9, 9, /*AVG FUEL CONS*/ 15, 15, /*FUEL ENGI*/ 15, 15, /*TYPE ENGI*/ 15, 15, /*POW ENGI*/ 21, 21, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 7, 7, /*COLOR INTE*/ 115, 115, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 18, 18, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 34, 34, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Wide-Trac", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 130, 130, /*PRICE*/ 93000, 93000, /*MAX FUEL*/ 350, 350, /*CURRENT FUEL*/ 350, 350, /*SPPED COEF*/ 11, 11, /*AVG FUEL CONS*/ 16, 16, /*FUEL ENGI*/ 17, 17, /*TYPE ENGI*/ 20, 20, /*POW ENGI*/ 21, 21, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 7, 7, /*COLOR INTE*/ 115, 115, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 18, 18, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 34, 34, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Cherokee", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 130, 130, /*PRICE*/ 104000,    104000, /*MAX FUEL*/ 360, 360, /*CURRENT FUEL*/ 360, 360, /*SPPED COEF*/ 13, 13, /*AVG FUEL CONS*/ 18, 18, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 18, 18, /*POW ENGI*/ 27, 27, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 7, 7, /*COLOR INTE*/ 116, 116, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 18, 18, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 34, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Creep", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 130, 130, /*PRICE*/ 105000,    105000, /*MAX FUEL*/ 360, 360, /*CURRENT FUEL*/ 360, 360, /*SPPED COEF*/ 13, 13, /*AVG FUEL CONS*/ 18, 18, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 18, 18, /*POW ENGI*/ 27, 27, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 7, 7, /*COLOR INTE*/ 116, 116, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 18, 18, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 12, 12}
            },

            {
                "Cowboy", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 124000,    124000, /*MAX FUEL*/ 360, 360, /*CURRENT FUEL*/ 360, 360, /*SPPED COEF*/ 13, 13, /*AVG FUEL CONS*/ 19, 19, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 17, 17, /*POW ENGI*/ 30, 30, /*TYPE TRANSM*/ 11, 11, /*SPEED COUNT*/ 7, 7, /*COLOR INTE*/ 116, 116, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 17, 17, /*TIRE*/ 17, 17, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 12, 12}
            },

            {
                "Freedom", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 156000,    156000, /*MAX FUEL*/ 400, 400, /*CURRENT FUEL*/ 400, 400, /*SPPED COEF*/ 9, 9, /*AVG FUEL CONS*/ 19, 19, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 18, 18, /*POW ENGI*/ 35, 35, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 8, 8, /*COLOR INTE*/ 116, 116, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 18, 18, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Wrangler", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 122000,    122000, /*MAX FUEL*/ 300, 300, /*CURRENT FUEL*/ 300, 300, /*SPPED COEF*/ 17, 17, /*AVG FUEL CONS*/ 14, 14, /*FUEL ENGI*/ 15, 15, /*TYPE ENGI*/ 13, 13, /*POW ENGI*/ 25, 25, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 116, 116, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 18, 18, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 34, 34, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },

            {
                "Ecco", new int[] { 1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, /*COLOUR*/ 132, 132, /*PRICE*/ 150000,    150000, /*MAX FUEL*/ 300, 300, /*CURRENT FUEL*/ 300, 300, /*SPPED COEF*/ 17, 17, /*AVG FUEL CONS*/ 12, 12, /*FUEL ENGI*/ 14, 14, /*TYPE ENGI*/ 14, 14, /*POW ENGI*/ 26, 26, /*TYPE TRANSM*/ 12, 12, /*SPEED COUNT*/ 6, 6, /*COLOR INTE*/ 116, 116, /*MATERIAL INTE*/ 13, 13, /*MATERIAL WHEEL*/ 13, 13, /*SIZE WHEEL*/ 18, 18, /*TIRE*/ 16, 16, /*COLOUR LIGHTS*/ 35, 35, /*POWER LIGHTS*/ 12, 12, /*PITCH*/ 11, 11}
            },
        };
    }


}

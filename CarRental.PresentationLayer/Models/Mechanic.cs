﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models
{
    public class Mechanic
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";
        
        // PROPERTIES

        public Guid Id { get; init; }
        public int Year { get; init; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public List<Repair> Repairs { get; init; }

        // CONSTRUCTORS

        // METHODS

        public override string ToString()
        {
            return $"{nameof(Id)} = {this.Id} | {nameof(Year)} = {this.Year} | {nameof(Name)} = {this.Name} | {nameof(Surename)} = {this.Surename} | {nameof(Id)} = {this.Id} |" /*Last repair = {Repairs[Repairs.Count - 1]}*/ /*CHECK NULL?*/;
        }
    }
}

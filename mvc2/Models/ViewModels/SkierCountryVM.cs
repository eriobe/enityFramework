using mvc2.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc2.Models.ViewModels
{
    public class SkierCountryVM
    {
        public Skier Skier { get; set; }
        public Country Country { get; set; }

        public int NumberOfSkiers { get; set; }
    }
}
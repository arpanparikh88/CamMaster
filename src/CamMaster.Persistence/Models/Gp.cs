﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class Gp
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int UnitId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Alert { get; set; }
    }
}
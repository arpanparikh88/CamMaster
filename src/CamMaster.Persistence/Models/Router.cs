﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class Router
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Version { get; set; }
        public string FactoryPassword { get; set; }
        public string Password { get; set; }
        public string Model { get; set; }
        public string Status { get; set; }
        public int? Signal { get; set; }
        public int? UnitId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
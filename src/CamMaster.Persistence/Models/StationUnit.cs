﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class StationUnit
    {
        public int Id { get; set; }
        public int? UnitId { get; set; }
        public int? StationId { get; set; }

        public virtual Station Station { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
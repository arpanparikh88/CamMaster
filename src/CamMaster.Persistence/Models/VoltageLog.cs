﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class VoltageLog
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UnitId { get; set; }
        public bool? Status { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
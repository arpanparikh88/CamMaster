﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class UnitFile
    {
        public int Id { get; set; }
        public int? UnitId { get; set; }
        public string Name { get; set; }
        public decimal? Size { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
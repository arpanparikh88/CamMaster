﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class PresetPtz
    {
        public int Id { get; set; }
        public int? UnitId { get; set; }
        public int? Horizontal { get; set; }
        public int? Vertical { get; set; }
        public int? Zoom { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
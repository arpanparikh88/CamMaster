// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class MaintenanceUnit
    {
        public int Id { get; set; }
        public bool? SpeakerStatus { get; set; }
        public bool? StrobeStatus { get; set; }
        public bool? ArduinoStatus { get; set; }
        public bool? RouterStatus { get; set; }
        public bool? StickerStatus { get; set; }
        public bool? MicriphoneStatus { get; set; }
        public bool? CamerasStatus { get; set; }
        public bool? AircardStatus { get; set; }
        public string DetailsUnit { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UnitId { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
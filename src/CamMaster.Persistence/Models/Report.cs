// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Report1 { get; set; }
        public int? IncidentId { get; set; }
        public string ReportNumber { get; set; }
        public bool? PoliceInformed { get; set; }
        public bool? StayLinePolice { get; set; }
        public bool? OthersPresent { get; set; }
        public bool? PropertyDamage { get; set; }
        public bool? AnyoneInjured { get; set; }
        public bool? MessagedClient { get; set; }
        public string TypesInjuries { get; set; }
        public string Perpetrator { get; set; }
        public string Cause { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Location { get; set; }
        public bool? SentVideo { get; set; }
        public int? SiteId { get; set; }
        public bool? VideoHd { get; set; }
        public bool? VideoLd { get; set; }
    }
}
// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class LiveDemonstration
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? Date { get; set; }
        public string Place { get; set; }
        public string Notes { get; set; }
        public TimeSpan? Time { get; set; }
        public int LeadId { get; set; }
        public int? UserId { get; set; }

        public virtual Lead Lead { get; set; }
        public virtual User User { get; set; }
    }
}
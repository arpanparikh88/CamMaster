// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class C1File
    {
        public int Id { get; set; }
        public int? ProposalUnitId { get; set; }
        public string Name { get; set; }
        public decimal? Size { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ProposalUnit ProposalUnit { get; set; }
    }
}
// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class Update
    {
        public int Id { get; set; }
        public int? ObjectId { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string OldField { get; set; }
        public string NewField { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; }
    }
}
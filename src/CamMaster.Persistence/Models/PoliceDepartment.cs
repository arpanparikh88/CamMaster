// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class PoliceDepartment
    {
        public PoliceDepartment()
        {
            Sites = new HashSet<Site>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Site> Sites { get; set; }
    }
}
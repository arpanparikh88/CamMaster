﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CamMaster.Persistence.Models
{
    public partial class ContactSite
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int SiteId { get; set; }
        public string CallingOrder { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Site Site { get; set; }
    }
}
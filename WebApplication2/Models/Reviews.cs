//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reviews
    {
        public int ReviewId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Content { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual User User { get; set; }
    }
}

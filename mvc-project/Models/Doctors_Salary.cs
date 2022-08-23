//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvc_project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Doctors_Salary
    {
        public int DocsId { get; set; }
        [Required]
        [Display(Name ="Visiting Day")]
        public string VisitingDay { get; set; }
        [Display(Name = "Pay Rate")]
        [Required]
        public decimal PayRate { get; set; }
        [Required]
        [Display(Name = "Total Hour")]
        public int TotalHour { get; set; }
        public int DoctorId { get; set; }
    
        public virtual Doctors_ Doctors_ { get; set; }
    }
}

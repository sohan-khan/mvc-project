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

    public partial class Nurse
    {
        public int NurseId { get; set; }
        [Display(Name ="Nurse Name")]
        public string Name { get; set; }
        [Required]
        public Nullable<int> Phone { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    
        public virtual Departments_ Departments_ { get; set; }
    }
}
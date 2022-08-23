using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using mvc_project.Models;
using mvc_project.Models.viewmodel;

namespace mvc_project.Models.viewmodel
{
    public class deptwisevm
    {

        //public int DeptwiseId { get; set; }
        public string DeptName { get; set; }
        public int DepartmentId { get; set; }

        public int DoctorId { get; set; }
        [Display(Name = "Doctor Name")]
        public string Name { get; set; }
     
        public string Designation { get; set; }
        public string Institution { get; set; }
        [Required]
        [Range(500,2000)]
        [Display(Name ="Visit Fee")]
        public decimal VisitFee { get; set; }
        public string Picture { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}
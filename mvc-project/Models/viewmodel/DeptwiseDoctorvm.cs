using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc_project.Models;
using mvc_project.Models.viewmodel;

namespace mvc_project.Models.viewmodel
{
    public class DeptwiseDoctorvm
    {
       public int DeptwiseId { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public string Designation { get; set; }
        public string Institution { get; set; }
        public decimal VisitFee { get; set; }
        public string Picture { get; set; }

        public HttpPostedFileBase Image { get; set; }

    }
}
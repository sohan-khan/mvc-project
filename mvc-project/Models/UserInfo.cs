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

    public partial class UserInfo
    {
        public int UserId { get; set; }
        [Required]
        [Display(Name="User Name")]
        public string Name { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password don't match")]
        public string Confirm_pass { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}

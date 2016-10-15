using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ClientViewModel
    {
        [Required]
        [Display(Name = "性")]
        [StringLength(10, ErrorMessage = "{0}超過{1}個長度")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0}超過{1}個長度")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0}超過{1}個長度")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
    }
}
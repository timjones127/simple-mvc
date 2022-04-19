using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMVC.ViewModels
{
    public class SubmitIncidentViewModel
    {
        [MaxLength(140)]
        [Required]
        [Display(Name = "Summary")]
        public string Title { get; set; }
        [Required(ErrorMessage ="An issue description is required")]
        [Display(Name = "Details of your issue")]
        public string Description { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Phone]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int? ClassificationId { get; set; }
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}

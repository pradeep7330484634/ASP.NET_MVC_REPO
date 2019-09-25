using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ef_codefirst_app.Models
{
    public class JobList
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name is required.")]

        public string CompanyName { get; set; }

        [Display(Name = "Job Role")]
        [Required(ErrorMessage = "Job Role is required.")]
        public string JobRole { get; set; }
        [Display(Name = "Description")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Invalid emaild address")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Skill is required.")]
        public string Skill { get; set; }
        [Required(ErrorMessage = "Timestamp is required.")]
        public string Timestamp { get; set; }
    }
}
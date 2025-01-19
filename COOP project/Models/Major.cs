using System;
using System.ComponentModel.DataAnnotations;

namespace COOP_project.Models
{
    public class Major
    {
        public int Id { get; set; }
		public Guid IdGuid { get; set; }
        [Display(Name = "Major Name")]
        [Required]
        public string majorName { get; set; }

        public bool isDeleted { get; set; }
    }
}

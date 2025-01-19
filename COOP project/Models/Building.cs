using System;
using System.ComponentModel.DataAnnotations;

namespace COOP_project.Models
{
    public class Building
    {
        public int Id { get; set; }
        public Guid IdGuid { get; set; }
        [Display(Name ="Building Name")]
        [Required]
        public string buildingName { get; set; }

        
        public bool isDeleted { get; set; }
    }
}

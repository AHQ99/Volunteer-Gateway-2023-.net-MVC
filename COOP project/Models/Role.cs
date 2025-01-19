using System;
using System.ComponentModel.DataAnnotations;

namespace COOP_project.Models
{
    public class Role
    {
        public int Id { get; set; }
		public Guid IdGuid { get; set; }
		[Required]
        [Display(Name = "Role Name")]
        public string roleName { get; set; }
    }
}

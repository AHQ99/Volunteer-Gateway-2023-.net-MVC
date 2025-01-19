using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace COOP_project.Models
{
    public class User
    {
        public int Id { get; set; }
		public Guid IdGuid { get; set; }
        [Display(Name = "Role Name")]
        public Role Role { get; set; }
        [Display(Name = "Role Name")]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Password")]
        [Required]
       // [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$", ErrorMessage = "The password worng ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public int Phone { get; set; }
        public bool isDeleted { get; set; }
    }
}

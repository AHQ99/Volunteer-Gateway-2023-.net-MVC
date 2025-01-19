using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COOP_project.Models
{
    public class Student
    {
        public int Id { get; set; }
		public Guid IdGuid { get; set; }
        [Display(Name = "Major Name")]
        public Major Major { get; set; }
        [Required]
        [Display(Name = "Major Name")]
        public int MajorId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }

        [Required]
        [Display(Name="User Name") ]
        public string user_Name { get; set; }
        [Display(Name = "Passowrd")]
        [Required]
        //[RegularExpression ("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$", ErrorMessage ="The password worng ")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required] 
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
        public bool isDeleted { get; set; }
    }
}

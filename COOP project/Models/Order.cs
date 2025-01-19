using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace COOP_project.Models
{
    public class Order
    {
        public int Id { get; set; }
		public Guid IdGuid { get; set; }
        [Display(Name = "Student Name")]
		public Student Student { get; set; }
        [Required]
        [Display(Name = "Student Name")]
        public int StudentId { get; set; }
        [Display(Name = "Work Name")]
        public volunteerWork Work { get; set; }
        [Required]
        [Display(Name = "Work Name")]
        public int WorkId { get; set; }

        [Required]
        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ordered Date")]
        public DateTime OrderDate { get; set; }
        public Order()
        {
            OrderDate = DateTime.Now;
        }
        [Display(Name = "Signed")]
        public bool isSigned { get; set; }
        [Display(Name = "Rejected")]
        public bool isRejected { get; set; }
        [Display(Name = "Accepted")]
        public bool isAccepted { get; set; }
        [Display(Name = "Done")]
        public bool isDone { get; set; }


        

    }
}

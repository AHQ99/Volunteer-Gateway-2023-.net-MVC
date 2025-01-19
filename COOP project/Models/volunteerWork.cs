using System;
using System.ComponentModel.DataAnnotations;

namespace COOP_project.Models
{
    public class volunteerWork
    {
        public int Id { get; set; }
		public Guid IdGuid { get; set; }
        [Display(Name = "Supervisor's Name")]
        public User User { get; set; }
        [Required]
        [Display(Name = "Supervisor's Name")]
        public int UserId { get; set; }
        [Display(Name = "Building Name")]
        public Building Building { get; set; }
        [Required]
        [Display(Name = "Building Name")]
        public int BuildingId { get; set; }
        [Display(Name = "Major Name")]
        public Major Major { get; set; }
        [Required]
        [Display(Name = "Major Name")]
        public int MajorId { get; set; }
        [Required]
        [Display(Name = "Work Name")]
        public string workName { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Start Date")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }
        [Required]
        [Display(Name = "Number of Students")]
        public int numOS { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Desc { get; set; }

        public bool status { get; set; }
        public bool isDeleted { get; set; }
    }
}

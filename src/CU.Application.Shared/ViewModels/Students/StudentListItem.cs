﻿using System.ComponentModel.DataAnnotations;

namespace CU.Application.Shared.ViewModels.Students
{
    public class StudentListItem
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public string FirstMidName { get; set; } = string.Empty;

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }

        public string LastName { get; set; } = string.Empty;
    }
}

﻿
namespace CU.Application.Shared.ViewModels.Courses
{
    public class CourseListItem
    {
        public int CourseID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Department { get; set; } = string.Empty;
    }
}

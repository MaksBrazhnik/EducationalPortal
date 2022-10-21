﻿namespace EducationalPortal.Domain.Entities
{
    public class UserCourse : BaseEntity
    {
        public int UserId { get; set; }

        public int CourseId { get; set; }

        public int PassPercent { get; set; }

        public bool IsPassed { get; set; }

        public User User { get; set; }

        public Course Course { get; set; }
    }
}

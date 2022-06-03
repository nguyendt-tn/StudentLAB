﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab04.Models
{
    public class CourseAssignment
    {
        public int id { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Course Course { get; set; }
    }
}
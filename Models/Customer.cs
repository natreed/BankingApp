using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApp.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime dateTime { get; set; }

        public Account Account { get; set; }

    }

//    public class Student
//    {
//        public int ID { get; set; }
//        public string LastName { get; set; }
//        public string FirstMidName { get; set; }
//        //public DateTime EnrollmentDate { get; set; }

//        public ICollection<Enrollment> Enrollments { get; set; }
//    }
}


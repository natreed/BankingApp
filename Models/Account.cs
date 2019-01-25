using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApp.Models
{
    public class Account
    {
        [ForeignKey("Customer")]
        public int AccountID { get; set; }
        public Double Balance { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime InitialTransactionDate { get; set; }

       
        public Customer Customer { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }

    //public enum Grade
    //{
    //    A, B, C, D, F
    //}

    //public class Enrollment
    //{
    //    public int EnrollmentID { get; set; }
    //    public int CourseID { get; set; }
    //    public int StudentID { get; set; }
    //    public Grade? Grade { get; set; }

    //    public Course Course { get; set; }
    //    public Student Student { get; set; }
    //}
}
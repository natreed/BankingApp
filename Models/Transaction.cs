using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BankingApp.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransactionID { get; set; }
        public float StartBalance { get; set; }
        public float TransactionAmount { get; set; }
        public float EndBalance { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TransactionTime { get; set; }

    }

    //public class Course
    //{
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public int CourseID { get; set; }
    //    public string Title { get; set; }
    //    public int Credits { get; set; }

    //    public ICollection<Enrollment> Enrollments { get; set; }
    //}
}

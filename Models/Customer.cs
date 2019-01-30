using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BankingApp.Models
{
    /// <summary>
    /// Customer is the primary entity in the Database. Each customer
    /// has exactly 1 Account entity. Each Account has a set of Transactions.
    /// To keep things simple, all queries and updates in this application 
    /// originate with the Customer Entity.
    /// </summary>
    public class Customer
    {
        // ATTRIBUTES
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = 
            "First name cannot be longer than 20 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = 
            "Last name cannot be longer than 20 characters.")]
        public string LastName { get; set; }

        [Display(Name="Phone Number")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date Opened")]
        [DisplayFormat(DataFormatString = 
            "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }

        [Display(Name = "Age")]
        public int customerAge { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + ", " + LastName; }
        }

        // NAVIGATION
        public Account Account { get; set; }        
    }
}


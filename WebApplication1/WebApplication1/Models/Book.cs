using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Book ID")]
        public int BookId { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "ISBN")]

        public string ISBN { get; set; }
        [Display(Name = "Author")]
        public string Author { get; set; }
        public virtual ICollection<Loan> bookLoans { get; set; }
    }
}
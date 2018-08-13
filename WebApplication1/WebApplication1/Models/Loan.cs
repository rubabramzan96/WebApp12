using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Loan ID")]
        public int LoanId { get; set; }


        [ForeignKey("associatedMember")]
        public int MemberId { get; set; }

        [ForeignKey("associatedBook")]
        public int BookId { get; set; }
        public virtual Member associatedMember { get; set; }
        public virtual Book associatedBook { get; set; }
    }
}
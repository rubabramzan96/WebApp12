using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Member ID")]
        public int MemberId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }
        [Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }
        public virtual ICollection<Loan> memberLoan { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_Data_Access_Layer_.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        //[MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime GetDateTime { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(15)]
        public int Pincode { get; set; }
        [ForeignKey("CandidateId")]
        //[InverseProperty("User")]
        public virtual Candidate Candidates { get; set; }
    }
}

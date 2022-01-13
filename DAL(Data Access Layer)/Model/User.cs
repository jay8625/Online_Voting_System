﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_Data_Access_Layer_.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string FirstName { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string LastName { get; set; }
        //[Required]
        public int Age { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string Email { get; set; }
        public string Gender { get; set; }
        //[Required]
        //[MaxLength(15)]
        public string PhoneNumber { get; set; }
        //[Required]
        public DateTime GetDateTime { get; set; }
        //[Required]
        //[MaxLength(100)]
        public string Address { get; set; }
        //[Required]
        //[MaxLength(15)]
        public int Pincode { get; set; }
        public int? ChoiceCandidateId { get; set; }
        [ForeignKey(nameof(ChoiceCandidateId))]
        public virtual Candidate Candidate { get; set; }
    }
}

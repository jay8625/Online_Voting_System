using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL_Data_Access_Layer_.Model
{
    public class Candidate
    {

        [Key]
        public int CandidateId { get; set; }
        [Required]
        [MaxLength(20)]
        public static string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public int LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public int Votes { get; set; }
    }
}

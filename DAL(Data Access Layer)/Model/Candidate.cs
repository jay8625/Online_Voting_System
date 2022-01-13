using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DAL_Data_Access_Layer_.Model
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        public string Gender { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        //Navigation Properties
        [InverseProperty("Candidate")]
        public virtual ICollection<User> Users { get; set; }
    }
}

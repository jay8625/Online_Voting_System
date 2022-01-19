using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_Data_Access_Layer_.Model
{
    public class Candidate
    {
        //Primary Key
        [Key]
        [Display(Name = "Candidate ID")]
        public int CandidateId { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }
        public string Gender { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        //Navigation Properties
        [InverseProperty("Candidate")]
        public virtual ICollection<User> Users { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_Data_Access_Layer_.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please Enter First Name")]
        [MaxLength(10)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^(0?[1-9]|[1-9][0-9]|[1][1-9][1-9]|99)$",ErrorMessage ="Valid!,Enter Suitable Age")]
        public int Age { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Select Gender")]
        public string Gender { get; set; }
        [Required]
        [MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name ="Date And Time")]
        public DateTime GetDateTime { get; set; }
        [Required]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [Required]
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        [Required]
        [MaxLength(20)]
        public string State { get; set; }
        [MaxLength(20)]
        public string Country { get; set; }
        [Required]
        public int PostalPincode { get; set; }
        public int? ChoiceCandidateId { get; set; }
        [ForeignKey(nameof(ChoiceCandidateId))]
        public virtual Candidate Candidate { get; set; }
    }
}

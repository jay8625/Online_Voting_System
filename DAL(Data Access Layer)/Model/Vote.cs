using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL_Data_Access_Layer_.Model
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public int VoterChoice { get; set; }
        [ForeignKey("UserId")]
        //[InverseProperty("Vote")]
        public virtual User User { get; set; }
    }
}

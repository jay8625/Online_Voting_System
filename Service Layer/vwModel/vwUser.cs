using DAL_Data_Access_Layer_.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.vwModel
{
    public class vwUser 
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? VoteStatus { get; set; }
    }
    
}

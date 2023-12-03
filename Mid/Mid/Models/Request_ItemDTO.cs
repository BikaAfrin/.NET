using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid.Models
{
    public class Request_ItemDTO
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public System.DateTime Expiredate { get; set; }
        public string Status { get; set; }
        public Nullable<int> RID { get; set; }
        public Nullable<int> EID { get; set; }
    }
}
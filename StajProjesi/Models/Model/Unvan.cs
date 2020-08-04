using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StajProjesi.Models.Model
{
    [Table("Unvan")]
    public class Unvan
    {
        [Key]
        public int Unvanid { get; set; }
        [Required]
        public String UnvanAdi { get; set; }
        public virtual ICollection<Users> Userss { get; set; }
    }
}
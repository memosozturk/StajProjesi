using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace StajProjesi.Models.Model
{
    [Table("Admin")]
   
 public class AdminInfo
 {
        [Key]
        public int Adminid { get; set; }
        [Required]
        public String Eposta { get; set; }
        [Required]
        public String Sifre { get; set; }


  }
}
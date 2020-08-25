using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StajProjesi.Models.Model
{
    [Table("Users")]
    public class Users
    {
        
        [Key]
        public int Userid { get; set; }
        [StringLength(50,ErrorMessage ="Uzunluk en fazla 50 karakter olabilir.")]
        public String UserAd { get; set; }
        [Required, StringLength(50, ErrorMessage = "Uzunluk en fazla 50 karakter olabilir.")]
        public String Eposta { get; set; }
        [Required,StringLength(50, ErrorMessage = "Uzunluk en fazla 50 karakter olabilir.")]
        public String Sifre { get; set; }
       
        public int? Unvanid { get; set; }
        public Unvan UserUnvan { get; set; }
        public int? Projeid { get; set; }
        public Proje ProjeUser { get; set; }



    }
    
   
}
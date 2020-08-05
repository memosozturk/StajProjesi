﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StajProjesi.Models.Model
{
    [Table("Proje")]
    public class Proje
    {
       //[Key]
       [ForeignKey("Users")]
        public int Projeid { get; set; }
        [Required,StringLength(100, ErrorMessage = "Uzunluk en fazla 100 karakter olabilir.")]
        public String ProjeAdi { get; set; }
        [StringLength(500, ErrorMessage = "Uzunluk en fazla 500 karakter olabilir.")]
        public String ProjeAciklama { get; set; }
        public Users Users{ get; set; }
        



    }
    
}
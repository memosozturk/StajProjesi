using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StajProjesi.Models.Model
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int Taskid { get; set; }
        [DisplayName("Task Başlık")]
        public String TaskBaslik { get; set; }
        [DisplayName("Task Açıklama")]
        public String TaskAciklama { get; set; }
        [DisplayName("Task Teslim Tarihi")]
        public  DateTime TaskTeslimTarihi { get; set; }
        public Users users { get; set; }
        public int Projeid { get; set; }
    }
}
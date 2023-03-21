using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaProject.DATA.Models
{
    public abstract class BaseModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}

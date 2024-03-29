﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EscolaProject.DATA.Models
{
    public partial class Materia : BaseModel
    {
        [Required]
        [Column("nome_materia")]
        [StringLength(10)]
        public string NomeMateria { get; set; }
        [Required]
        [Column("descricao")]
        [StringLength(10)]
        public string Descricao { get; set; }

        [NotMapped]
        public virtual Notas Notas { get; set; }

        [NotMapped]
        public virtual bool Selecionada { get; set; }

        [NotMapped]
        public virtual List<MateriaAluno> MateriasAlunos { get; set; }
    }
}
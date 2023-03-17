using System.ComponentModel.DataAnnotations;

namespace TodoListApi.Models
{
    public class Tarefa
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string descricao { get; set; }
        [Required]
        [Display(Name = "Data do vencimento")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataVencimento { get; set; }
    }
}

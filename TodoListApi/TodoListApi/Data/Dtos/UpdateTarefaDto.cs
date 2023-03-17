using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TodoListApi.Data.Dtos
{
    public class UpdateTarefaDto
    {
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

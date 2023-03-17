namespace TodoListApi.Data.Dtos
{
    public class ReadTarefaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}

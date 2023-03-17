using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;

namespace TodoListApi.Data
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> opts) : base(opts) { 
        
        
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}

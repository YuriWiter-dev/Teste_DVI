using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListApi.Data;
using TodoListApi.Data.Dtos;
using TodoListApi.Models;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private TarefaContext _context;
        private IMapper _mapper;

        public TodoController(TarefaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        /// <summary>
        /// Adiciona uma tarefa ao banco de dados
        /// </summary>
        /// <param name="TarefaDto">Objeto com os campos necessários para criação de uma tarefa</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>

        [HttpPost]
        public IActionResult AdicionaTarefa([FromBody] CreateTarefaDto tarefaDto)
        {
            //if (tarefa.DataVencimento.Year <= 2022) {
            //}

            Tarefa tarefa = _mapper.Map<Tarefa>(tarefaDto);
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaTarefaPorID), new { id = tarefa.Id }, tarefa);
        }
        /// <summary>
        /// Recupera uma lista de tarefas do banco de dados
        /// </summary>
        /// <returns>Informações dos tarefas buscados</returns>
        /// <response code="200">Com a lista de tarefas presentes na base de dados</response>
        [HttpGet]
        public IEnumerable<ReadTarefaDto> RecuperaTarefa()
        {
            return _mapper.Map<List<ReadTarefaDto>>(_context.Tarefas);

        }
        /// <summary>
        /// Recupera uma tarefa no banco de dados usando seu id
        /// </summary>
        /// <param name="id">Id ds tarefa a ser recuperado no banco</param>
        /// <returns>Informações da tarefa buscado</returns>
        /// <response code="200">Caso o id seja existente na base de dados</response>
        /// <response code="404">Caso o id seja inexistente na base de dados</response>
        [HttpGet("{Id}")]
        public IActionResult RecuperaTarefaPorID(int Id) {

            var tar = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == Id);
            if (tar != null)
            {
                var tarefaDto = _mapper.Map<ReadTarefaDto>(tar);
                return Ok(tarefaDto);
            }
            return NotFound();

        }

        /// <summary>
        /// Atualiza uma tarefa no banco de dados usando seu id
        /// </summary>
        /// <param name="id">Id da tarefa a ser atualizado no banco</param>
        /// <param name="tarefaDto">Objeto com os campos necessários para atualização de uma tarefa</param>
        /// <returns>Sem conteúdo de retorno</returns>
        /// <response code="204">Caso o id seja existente na base de dados e o tarefa tenha sido atualizado</response>
        /// <response code="404">Caso o id seja inexistente na base de dados</response>
        [HttpPut("{Id}")]
        public IActionResult AtualizaTarefa(int Id, [FromBody] UpdateTarefaDto tarefaDto)
        {
            var tarefaSelecionada = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == Id);

            if (tarefaSelecionada != null)
            {
                _mapper.Map(tarefaDto, tarefaSelecionada);
                _context.SaveChanges();
            }
            return NoContent();
        }

        [HttpPatch("{Id}")]
        public IActionResult AtualizaTarefaParcialmente(int Id, JsonPatchDocument<UpdateTarefaDto> patch)
        {
            var tarefaSelecionada = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == Id);

            if (tarefaSelecionada != null)
            {
                var TarefaParaAtualizar = _mapper.Map<UpdateTarefaDto>(tarefaSelecionada);
                patch.ApplyTo(TarefaParaAtualizar, ModelState);

                if (!TryValidateModel(TarefaParaAtualizar))
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(TarefaParaAtualizar, tarefaSelecionada);
                _context.SaveChanges();
            }
            return NoContent();
        }


        /// <summary>
        /// Deleta um tarefa do banco de dados usando seu id
        /// </summary>
        /// <param name="id">Id do tarefa a ser removido do banco</param>
        /// <returns>Sem conteúdo de retorno</returns>
        /// <response code="204">Caso o id seja existente na base de dados e o tarefa tenha sido removido</response>
        /// <response code="404">Caso o id seja inexistente na base de dados</response>
        [HttpDelete("{Id}")]
        public IActionResult DeletarTarefa(int Id)
        {
            var tarefaSelecionada = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == Id);

            _context.Remove(tarefaSelecionada);
            _context.SaveChanges();
            return NoContent();


            
        }
    }
}

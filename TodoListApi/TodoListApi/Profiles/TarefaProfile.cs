using AutoMapper;
using System.Runtime.InteropServices;
using TodoListApi.Data.Dtos;
using TodoListApi.Models;

namespace TodoListApi.Profiles
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
           
            CreateMap<CreateTarefaDto, Tarefa>();
            CreateMap<UpdateTarefaDto, Tarefa>();
            CreateMap<Tarefa, UpdateTarefaDto>();
            CreateMap<Tarefa, ReadTarefaDto>();
        }
    }
}

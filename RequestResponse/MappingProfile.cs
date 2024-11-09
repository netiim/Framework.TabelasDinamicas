using AutoMapper;
using Core.Entidades;
using DTOs.TablesModel;

namespace Core.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TableModel, CreateTableModelDTO>()
                .ReverseMap();
            CreateMap<CreateColunaDTO, Coluna>()
                .ReverseMap();
        }
    }
}
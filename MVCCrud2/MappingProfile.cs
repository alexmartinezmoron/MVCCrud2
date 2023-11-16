using AutoMapper;
using MVCCrud2.Models;
using MVCCrud2.VeiwModels;

namespace MVCCrud2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddClienteVeiwModel, Cliente>();
            CreateMap<Cliente, AddClienteVeiwModel>();
        }
    }
}
using AutoMapper;
using CursoArquitecturaNet.Core.Entities;
using CursoArquitecturaNet.DTOs;

namespace CursoArquitecturaNet.Mapper
{
    public class ProductMapperProfiles : Profile
    {
        public ProductMapperProfiles()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}

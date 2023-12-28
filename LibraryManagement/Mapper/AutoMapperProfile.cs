using AutoMapper;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos;

namespace LibraryManagement.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book,BookDto>().ReverseMap();
        }
    }
}

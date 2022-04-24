using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs.Book;


namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookListDto>().ReverseMap();
            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap().ForAllMembers(m => m.Condition((dest, src, obj) => obj != null));

        }
    }
}

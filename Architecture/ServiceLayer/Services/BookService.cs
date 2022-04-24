using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(BookCreateDto bookCreateDto)
        {
            var model = _mapper.Map<Book>(bookCreateDto);
            await _repository.CreateAsync(model);
            
        }

        public async Task<List<BookListDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<BookListDto>>(model);

            return res;
        }

        public async Task UpdateAsync(int id, BookUpdateDto bookUpdateDto)
        {
            var entity = await _repository.GetAsync(id);

            _mapper.Map(bookUpdateDto, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetAsync(id);

            await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<BookListDto>> GetAllByConditionsAsync(string search)
        {
            return _mapper.Map<IEnumerable<BookListDto>>(await _repository.FindAllAsync(m => m.Name.Contains(search)));
        }
    }
}

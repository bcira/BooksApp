using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.DataTransferObjects.Responses;
using BooksApp.Infrastructure.Repositories;
using BooksApp.Services.Extensions;

namespace BooksApp.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public CategoryService(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<CategoryDisplayResponse> GetCategoriesForList()
        {
            var items = _repository.GetAll();
            var responses = items.ConvertToDto(_mapper);
            return responses;
        }
    }
}

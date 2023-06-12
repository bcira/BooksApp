using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BooksApp.DataTransferObjects.Responses;
using BooksApp.DataTransferObjects.Requests;
using BooksApp.Entities;

namespace BooksApp.Services.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookDisplayResponse>();
            CreateMap<Category, CategoryDisplayResponse>();
            CreateMap<CreateNewBookRequest, Book>();
            CreateMap<UpdateBookRequest, Book>().ReverseMap();

        }


    }
}

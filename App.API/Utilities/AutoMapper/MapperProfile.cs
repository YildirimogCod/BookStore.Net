using AutoMapper;
using Models;
using Models.Dtos;

namespace App.API.Utilities.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<UpdateBookRequest, Book>();
        }
    }
}

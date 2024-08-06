using AutoMapper;
using Test.Domain.Entities.Test;
using Test.Queries.Application.Entities.Test.Dtos;

namespace Test.Queries.Application.Mapper.Test
{
    public class Test : Profile
    {
        public Test()
        {
            CreateMap<TestEntity, TestDto>();
        }
    }
}

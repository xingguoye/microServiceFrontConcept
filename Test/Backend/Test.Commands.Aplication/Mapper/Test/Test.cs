using AutoMapper;
using Test.Commands.Application.Entities.Test.Dtos;
using Test.Domain.Entities.Test;
using Test.Domain.RabbitMQ;

namespace Test.Commands.Application.Mapper.Test
{
    public class Test : Profile
    {
        public Test()
        {
            CreateMap<TestDto, TestEntity>();
            CreateMap<TestCreateDto, TestEntity>();
            CreateMap<TestDeleteDto, TestEntity>();

            CreateMap<TestDto, RBTest>();
            CreateMap<TestCreateDto, RBTestCreate>();
            CreateMap<TestDeleteDto, RBTestDelete>();
        }
    }
}

using AutoMapper;
using Test.Consumer.Application.Entities.Test.Dtos;
using Test.Domain.Entities.Test;
using Test.Domain.RabbitMQ;

namespace Test.Consumer.Application.Mapper.Test
{
    public class Test : Profile
    {
        public Test()
        {
            CreateMap<TestDto, TestEntity>();
            CreateMap<TestCreateDto, TestEntity>();
            CreateMap<TestDeleteDto, TestEntity>();

            CreateMap<RBTest, TestDto>();
            CreateMap<RBTestCreate, TestCreateDto>();
            CreateMap<RBTestDelete, TestDeleteDto>();
        }
    }
}

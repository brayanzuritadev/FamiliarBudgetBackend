using AutoMapper;
using Data.DTOs;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utilities
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserCreation,User>();
            CreateMap<FamilyCreation,Family>();
            CreateMap<User, UserResponse>();
            CreateMap<TransactionCreation,Transaction>();
            CreateMap<Transaction, TransactionResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name));
                
            CreateMap<User,TransactionResponse>();
        }
    }
}

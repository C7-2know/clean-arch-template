using AutoMapper;
using BlogPost.Application.Common.DTOs.Rate;
using BlogPost.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BlogPost.Application.Profiles;
public class MappingProfile :Profile
{
    public MappingProfile()
    {
        CreateMap<Rate,RateDto>().ReverseMap();
    }
}

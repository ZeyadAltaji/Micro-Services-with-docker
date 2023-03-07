﻿using AutoMapper;
using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileAutoMapper
{
    public class PlatfromProfrile:Profile
    {
        public PlatfromProfrile()
        {
            // Source -> Target
            CreateMap<PlatfromsReadDto, Platfrom>().ReverseMap();
            CreateMap<PlatfromCreateDTO, Platfrom>().ReverseMap();
        }
    }
}

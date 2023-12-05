﻿using AutoMapper;
using Revisao.Data.Providers.MongoDb.Colletions;
using Revisao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.AutoMapper
{
    public class DomainToCollection : Profile
    {
        public DomainToCollection()
        {
            CreateMap<Carta, CartaCollection>();
        }
    }
}

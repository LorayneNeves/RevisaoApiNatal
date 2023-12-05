using AutoMapper;
using Revisao.Data.Providers.MongoDb.Colletions;
using Revisao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.AutoMapper
{
    public class CollectionToDomain : Profile
    {
        public CollectionToDomain()
        {

            CreateMap<CartaCollection, Carta>()
               .ConstructUsing(q => new Carta(q.idCarta, q.Nome, q.Rua, q.Cidade, q.Bairro, q.Estado, q.Numero, q.Idade, q.Descricao));

        }

    }
}

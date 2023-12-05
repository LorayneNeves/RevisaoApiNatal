using AutoMapper;
using Newtonsoft.Json;
using Revisao.Data.Providers.MongoDb.Colletions;
using Revisao.Data.Providers.MongoDb.Interfaces;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Repositories
{
    public class CartaRepository : ICartaRepository
    {
        private readonly IMongoRepository<CartaCollection> _cartaRepository;
        private readonly IMapper _mapper;
        #region - Construtores
        public CartaRepository(IMongoRepository<CartaCollection> cartaRepository, IMapper mapper)
        {
            _cartaRepository = cartaRepository;
            _mapper = mapper;
        }

        #endregion

        #region - Funções
        public async Task Adicionar(Carta carta)
        {
            await _cartaRepository.InsertOneAsync(_mapper.Map<CartaCollection>(carta));
        }

        public async Task Atualizar(Carta carta)
        {
            var buscaCarta = _cartaRepository.FilterBy(filter => filter.idCarta == carta.idCarta);


            if (buscaCarta == null) { throw new ApplicationException("Carta não encontrada"); }

            var cartaCollection = _mapper.Map<CartaCollection>(carta);
            cartaCollection.Id = buscaCarta.FirstOrDefault().Id;

            cartaCollection.Nome = carta.Nome;
            cartaCollection.Descricao = carta.Descricao;
            cartaCollection.Rua = carta.Rua;
            cartaCollection.Cidade = carta.Cidade;
            cartaCollection.Bairro = carta.Bairro;
            cartaCollection.Numero = carta.Numero;
            cartaCollection.Idade = cartaCollection.Idade;



             await _cartaRepository.ReplaceOneAsync(cartaCollection);
        }

        public async Task<Carta> ObterPorId(Guid id)
        {
            var buscaCarta = _cartaRepository.FilterBy(filter => filter.idCarta == id);

            var carta = _mapper.Map<Carta>(buscaCarta.FirstOrDefault());

            return carta;
        }

        public IEnumerable<Carta> ObterTodos()
        {
            var cartaList = _cartaRepository.FilterBy(filter => true);

            return _mapper.Map<IEnumerable<Carta>>(cartaList);
        }
        #endregion


    }
}

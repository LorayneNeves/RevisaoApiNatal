using AutoMapper;
using Revisao.Application.Interfaces;
using Revisao.Application.ViewModels;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Application.Services
{
    public class CartaService : ICartaService
    {
        #region - Construtores
        private readonly ICartaRepository _cartaRepository;
        private IMapper _mapper;

        public CartaService(ICartaRepository cartaRepository, IMapper mapper)
        {
            _cartaRepository = cartaRepository;
            _mapper = mapper;
        }
        #endregion

        #region - Funções
        public async Task Adicionar(NovaCartaViewModel novaCartaViewModel)
        {
            var novaCarta = _mapper.Map<Carta>(novaCartaViewModel);
            Carta c = new Carta
            (
               novaCartaViewModel.Nome, novaCartaViewModel.Descricao, novaCartaViewModel.Idade, novaCartaViewModel.Rua,
               novaCartaViewModel.Bairro, novaCartaViewModel.Numero, novaCartaViewModel.Cidade, novaCartaViewModel.Estado
            );
            await _cartaRepository.Adicionar(novaCarta);

        }
        public async Task Atualizar(Guid id, CartaViewModel cartaViewModel)
        {
            var buscaCarta = await _cartaRepository.ObterPorId(id);

            if (buscaCarta == null) throw new ApplicationException("Não é possível atualizar um produto que não existe!");

            buscaCarta.AlterarDescricao(cartaViewModel.Descricao);            

            await _cartaRepository.Atualizar(buscaCarta);
        }


        public async Task<CartaViewModel> ObterPorId(Guid id)
        {
            var buscaCarta = await _cartaRepository.ObterPorId(id);

            if (buscaCarta == null)
            {
                throw new ApplicationException("Produto não encontrado");
            }

            var cartaViewModel = new CartaViewModel
            {
                idCarta = buscaCarta.idCarta,
                Nome = buscaCarta.Nome,
                Descricao = buscaCarta.Descricao,
                Rua = buscaCarta.Rua,
                Cidade = buscaCarta.Cidade,
                Bairro = buscaCarta.Bairro,
                Estado = buscaCarta.Estado,
                Numero = buscaCarta.Numero,
                Idade = buscaCarta.Idade,
            };
            return cartaViewModel;
        }

        public IEnumerable<CartaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CartaViewModel>>(_cartaRepository.ObterTodos());
        }
        #endregion
    }
}

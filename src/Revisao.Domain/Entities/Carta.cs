using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Domain.Entities
{
    public class Carta
    {
        #region 1 - Contrutores
        public Carta(string nome, string descricao, int idade, string rua, string bairro, int numero, string cidade, string estado)
        {
            Nome = nome;
            Descricao = descricao;
            Idade = idade;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
        }

        public Carta(Guid idCarta, string nome, string rua, string cidade, string bairro, string estado, int numero, int idade, string descricao)
        {
            this.idCarta = idCarta;
            Nome = nome;
            Rua = rua;
            Cidade = cidade;
            Bairro = bairro;
            Estado = estado;
            Numero = numero;
            Idade = idade;
            Descricao = descricao;
        }


        #endregion

        #region 2 - Propriedades
        public Guid idCarta { get; private set; }
        public string Nome { get; private set; }
        public string Rua { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Estado { get; private set; }
        public int Numero { get; private set; }
        public int Idade { get; private set; }
        public string Descricao { get; private set; }
        #endregion

        #region 3 - Comportamentos
        public void AlterarDescricao(string descricao) => Descricao = descricao;

        public void Atualizar(string nome, string descricao, string rua, string cidade, string estado, int numero, int idade)
        {
            Nome = nome;
            Descricao = descricao;
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
            Idade = idade;
        }

        #endregion
    }
}

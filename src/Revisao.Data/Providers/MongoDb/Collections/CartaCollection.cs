using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Providers.MongoDb.Colletions
{
    [BsonCollection("Carta")]
    public class CartaCollection : Document
    {
        #region 2 - Propriedades
        public Guid idCarta { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public int Numero { get; set; }
        public int Idade { get; set; }

        #endregion
    }
}

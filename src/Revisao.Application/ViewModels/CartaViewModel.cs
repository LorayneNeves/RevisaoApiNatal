using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Application.ViewModels
{
    public class CartaViewModel
    {
        public Guid idCarta { get;  set; }
        public string Nome { get;  set; }
        public string Rua { get;  set; }
        public string Cidade { get;  set; }
        public string Bairro { get;  set; }
        public string Estado { get;  set; }
        public int Numero { get;  set; }
        //[CartasValidationAttribute]
        public int Idade { get;  set; }
        public string Descricao { get;  set; }
    }
}

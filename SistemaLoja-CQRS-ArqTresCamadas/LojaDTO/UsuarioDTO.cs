using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDTO
{
    public class UsuarioDTO
    {
        public int codigo_cliente { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime Cadastro { get; set; }
        public string situacao { get; set; }
        public int perfil { get; set; }
    }
}

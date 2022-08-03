using System;
using System.Collections.Generic;

#nullable disable

namespace Permissoes_WebApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdTiposUsuario { get; set; }
        public int? Idstatus { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        public virtual TiposUsuario IdTiposUsuarioNavigation { get; set; }
        public virtual Status IdstatusNavigation { get; set; }
    }
}

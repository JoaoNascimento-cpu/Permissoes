using System;
using System.Collections.Generic;

#nullable disable

namespace Permissoes_WebApi.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTiposUsuario { get; set; }
        public string TituloTiposUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

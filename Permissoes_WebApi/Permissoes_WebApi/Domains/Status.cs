using System;
using System.Collections.Generic;

#nullable disable

namespace Permissoes_WebApi.Domains
{
    public partial class Status
    {
        public Status()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdStatus { get; set; }
        public string TituloStatus { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vestsys.Models.Entities;

namespace vestsys.Models.Abstract
{
    public interface IUsuario
    {
        int CadastradarUsuario(Usuario user);
        string EditarUsuario(Usuario user);
        string DeletarUsuario(Usuario user);
        List<Usuario> ListarUsuarios();
        Usuario BuscarUsuario(int? id);

    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISecurityService
    {
        Usuario GetLoginByCredentials(UsuarioLogin login);

        void RegisterUser(Usuario user);

        Usuario RecoverPw(UsuarioLogin login);

        (Administrador, Docente, Alumno) MergeUser(int userId);

        Usuario MergeUserReturnUser(int userId);

        bool UpdateUser(Usuario user);
        bool DeleteUser(int id); 

    }
}

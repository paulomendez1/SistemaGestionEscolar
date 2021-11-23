using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Usuario>
    {
        Usuario GetLoginByCredentials(UsuarioLogin login);

        Usuario RecoverPw(UsuarioLogin login);

        (Administrador, Docente, Alumno) MergeUser(int userId);

        Usuario MergeUserReturnUser(int userId);

    }
}

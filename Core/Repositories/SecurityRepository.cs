using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class SecurityRepository : BaseRepository<Usuario>, ISecurityRepository
    {
        private readonly IDocenteRepository _docenteRepository = new DocenteRepository();
        private readonly IAlumnoRepository _alumnoRepository = new AlumnoRepository();
        private readonly IRepository<Administrador> _adminRepository = new BaseRepository<Administrador>();

        public Usuario GetLoginByCredentials(UsuarioLogin login)
        {
            return GetAll().Where(x => x.Email == login.Email && x.Contraseña == login.Contraseña).FirstOrDefault();
        }

        public Usuario RecoverPw(UsuarioLogin login)
        {
            return GetAll().Where(x => x.Email == login.Email).FirstOrDefault();
        }

        public (Administrador, Docente, Alumno) MergeUser(int userId)
        {
            var user = GetAll().Where(x=> x.Id == userId).FirstOrDefault();
            if (user.RolId == 1)
            {
                return (_adminRepository.GetAll().Where(x => x.UsuarioId == userId).FirstOrDefault(), null, null);
            }
            if (user.RolId == 2)
            {
                return (null, _docenteRepository.GetAll().Where(x => x.UsuarioId == userId).FirstOrDefault(), null);
            }
            if (user.RolId == 3)
            {
                return (null, null, _alumnoRepository.GetAll().Where(x => x.UsuarioId == userId).FirstOrDefault());
            }
            return (null, null, null);
        }

        public Usuario MergeUserReturnUser(int userId)
        {
            var user = GetAll().Where(x => x.Id == userId).FirstOrDefault();
            return user;
        }

    }
}

using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDocenteRepository DocenteRepository { get; }
        IAlumnoRepository AlumnoRepository { get; }
        ISecurityRepository SecurityRepository { get; }

        IBackUpRepository BackUpRepository { get; }
        IRepository<Administrador> AdminRepository { get; }
        IRepository<Materia> MateriaRepository { get; }
        IEvaluacionRepository EvaluacionRepository { get; }
        IClaseRepository ClaseRepository { get; }

        IRepository<Asistencia> AsistenciaRepository { get; }
        IFinanzaRepository FinanzaRepository { get; }
        IRepository<Aviso> AvisoRepository { get; }

        void WriteXML(DataSet ds);
    }
}

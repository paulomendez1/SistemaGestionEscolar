using Core.Entities;
using Core.Interfaces;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDocenteRepository _docenteRepository = new DocenteRepository();
        private readonly IAlumnoRepository _alumnoRepository = new AlumnoRepository();
        private readonly ISecurityRepository _securityRepository = new SecurityRepository();
        private readonly IBackUpRepository _backUpRepository = new BackUpRepository();
        private readonly IRepository<Administrador> _adminRepository = new BaseRepository<Administrador>();
        private readonly IRepository<Materia> _materiaRepository = new BaseRepository<Materia>();
        private readonly IEvaluacionRepository _evaluacionRepository = new EvaluacionRepository();
        private readonly IClaseRepository _claseRepository = new ClaseRepository();
        private readonly IRepository<Asistencia> _asistenciaRepository = new BaseRepository<Asistencia>();
        private readonly IFinanzaRepository _finanzaRepository = new FinanzaRepository();
        private readonly IRepository<Aviso> _avisoRepository = new BaseRepository<Aviso>();

        public IDocenteRepository DocenteRepository => _docenteRepository ?? new DocenteRepository();
        public IAlumnoRepository AlumnoRepository => _alumnoRepository ?? new AlumnoRepository();
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository();
        public IBackUpRepository BackUpRepository => _backUpRepository ?? new BackUpRepository();
        public IRepository<Administrador> AdminRepository => _adminRepository ?? new BaseRepository<Administrador>();
        public IRepository<Materia> MateriaRepository => _materiaRepository ?? new BaseRepository<Materia>();
        public IEvaluacionRepository EvaluacionRepository => _evaluacionRepository ?? new EvaluacionRepository();
        public IClaseRepository ClaseRepository => _claseRepository ?? new ClaseRepository();
        public IRepository<Asistencia> AsistenciaRepository => _asistenciaRepository ?? new BaseRepository<Asistencia>();

        public IFinanzaRepository FinanzaRepository => _finanzaRepository ?? new FinanzaRepository();
        public IRepository<Aviso> AvisoRepository => _avisoRepository ?? new BaseRepository<Aviso>();

        public void Dispose()
        {
           
        }

        public void WriteXML(DataSet _ds)
        {
            _ds.WriteXml("C:/Users/paulo/source/repos/SistemaGestionEscolarV4.0/Data/XML/DB.Xml");
        }
    }
}

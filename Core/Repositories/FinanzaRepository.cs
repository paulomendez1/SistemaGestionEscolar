using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class FinanzaRepository : BaseRepository<Finanza>, IFinanzaRepository
    {
        private readonly IDocenteRepository _docenteRepository = new DocenteRepository();
        private readonly IAlumnoRepository _alumnoRepository = new AlumnoRepository();

        public decimal GetTotal()
        {
            decimal ingresos = GetTotalIngresos();
            decimal egresos = GetTotalEgresos();
            return ingresos - egresos;
        }

        public int GetTotalAlumnos()
        {
            int TotalAlumnos = _alumnoRepository.GetAll().Count();
            return TotalAlumnos;
        }

        public int GetTotalDocentes()
        {
            int TotalDocentes = _docenteRepository.GetAll().Count();
            return TotalDocentes;
        }

        public decimal GetTotalEgresos()
        {
            decimal sueldos = GetTotalSueldoDocentes();
            decimal servicios = GetById(1).ValorServicio;
            return sueldos + servicios;
        }

        public decimal GetTotalIngresos()
        {
            int alumnos = GetTotalAlumnos();
            decimal cuota = GetById(1).ValorCuota;
            return (decimal)alumnos * cuota;
        }

        public decimal GetTotalSueldoDocentes()
        {
            decimal TotalDocentes = _docenteRepository.GetAll().Select(x=>x.Sueldo).Sum();
            return TotalDocentes;
        }
    }
}

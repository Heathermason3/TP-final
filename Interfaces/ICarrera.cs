using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp_final_ballon.Clases;

namespace Tp_final_ballon.Interfaces
{
    public interface ICarrera
    {
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public static List<Carrera> Carreras { get; set; }

        public Carrera FindBySigla(string sigla);
        public string Lista();
        public bool NameExist(string name);
        public bool SiglaExist(string sigla);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp_final_ballon.Interfaces;

namespace Tp_final_ballon.Clases
{
    public class Carrera : IABMC<Carrera>, IID, ICarrera
    {
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public int ID { get; set; }
        private static List<Carrera> _carreras = new List<Carrera>();
        private static int LastId = 1;

        public override string ToString()
        {
            return "Nombre: " + Nombre + "Sigla: " + Sigla + "TItulo: " + Titulo;
        }

        public void Add(Carrera carrera)
        {
            if (NameExist(carrera.Nombre))
                throw new Exception("Existe otra carrera con ese nombre");
            if (SiglaExist(carrera.Sigla))
                throw new Exception("Existe otra carrera con esta sigla");

            carrera.ID = LastId;
            LastId++;
            _carreras.Add(carrera);
        }

        public void Erase(int id)
        {
            foreach (Carrera c in _carreras)
            {
                if (c.ID == id)
                {
                    _carreras.Remove(c);
                    return;
                }
            }
            throw new NotImplementedException("No se encontro una carrera con esta ID: " + id);
        }

        public Carrera Find(int id)
        {
            foreach (Carrera c in _carreras)
            {
                if (c.ID == id)
                {
                    return c;
                }
            }
            throw new NotImplementedException("No se encontro una carrera con esta ID: " + id);
        }

        public string Lista()
        {
            string carreras = "";
            foreach (Carrera c in _carreras)
            {
                carreras += c.ToString();
            }
            return carreras;
        }

        public bool NameExist(string name)
        {
            foreach (Carrera c in _carreras)
            {
                if (c.Nombre == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool SiglaExist(string sigla)
        {
            Carrera c = FindBySigla(sigla);
            if (c != null)
                return true;
            return false;
        }

        public void Modify(Carrera data)
        {
            Carrera c = Find(data.ID);
            if (c != null)
                throw new NotImplementedException("No se encontro ninguna carrera");
            c.Nombre = data.Nombre;
        }

        public Carrera FindBySigla(string sigla)
        {
            foreach (Carrera c in _carreras)
            {
                if (c.Sigla == sigla)
                {
                    return c;
                }
            }
            throw new NotImplementedException(
                "No se encontro una carrera con esta sigla: " + sigla
            );
        }
    }
}

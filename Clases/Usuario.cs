using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp_final_ballon.Interfaces;

namespace Tp_final_ballon.Clases
{
    public class Usuario : IABMC<Usuario>, IID, IUsuario
    {
        private static int LastId = 1;
        public int ID { get; set; }
        public string Name { get; set; }
        public int DNI { get; set; }
        public string Mail { get; set; }
        private static List<Usuario> _usuarios = new List<Usuario>();

        public override string ToString()
        {
            return "Nombre: " + Name + "Mail: " + Mail + "DNI: " + DNI;
        }

        public void Add(Usuario usuario)
        {
            if (MailExist(usuario.Mail))
                throw new Exception("Existe otro usuario con ese mail");
            if (DniExist(usuario.DNI))
                throw new Exception("Existe otro usuario con ese DNI");

            usuario.ID = LastId;
            LastId++;
            _usuarios.Add(usuario);
        }

        public bool DniExist(int dni)
        {
            Usuario u = FindByDni(dni);
            if (u != null)
                return true;
            return false;
        }

        public void Erase(int id)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.ID == id)
                {
                    _usuarios.Remove(u);
                    return;
                }
            }
            throw new NotImplementedException("No se encontro un usuario con esta ID: " + id);
        }

        public Usuario Find(int id)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.ID == id)
                {
                    return u;
                }
            }
            throw new NotImplementedException("No se encontro usuario con esta ID: " + id);
        }

        public Usuario FindByDni(int dni)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.DNI == dni)
                {
                    return u;
                }
            }
            throw new NotImplementedException("No se encontron usuario con este DNI: " + dni);
        }

        public Usuario FindByMail(string mail)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.Mail == mail)
                {
                    return u;
                }
            }
            throw new NotImplementedException("No se encontron usuario con este Mail: " + mail);
        }

        public string List()
        {
            string lista = "";
            foreach (Usuario u in _usuarios)
            {
                lista += u.ToString();
            }
            return lista;
        }

        public bool MailExist(string mail)
        {
            Usuario u = FindByMail(mail);
            if (u != null)
                return true;
            return false;
        }

        public void Modify(Usuario usuario)
        {
            Usuario u = Find(usuario.ID);
            if (u == null)
                throw new NotImplementedException("El usuario no se encontro");
            u.Name = usuario.Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp_final_ballon.Clases;

namespace Tp_final_ballon.Interfaces
{
    public interface IUsuario
    {
        public string Name { get; set; }
        public int DNI { get; set; }
        public string Mail { get; set; }

        public bool DniExist(int dni);
        public bool MailExist(string mail);
        public string List();
        public Usuario FindByMail(string mail);
        public Usuario FindByDni(int dni);

        public static List<Usuario> Lista { get; set; }
    }
}

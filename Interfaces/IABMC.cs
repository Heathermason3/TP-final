using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_final_ballon.Interfaces
{
    public interface IABMC<T>
    {
        public void Modify(T data);
        public void Add(T usuario);
        public void Erase(int Id);
        public T Find(int Id);
    }
}

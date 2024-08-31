using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_OOP_Bai2
{
    abstract class Vector
    {
        public abstract string ShowInfo();
        public abstract Vector Sum(Vector v);
        public abstract bool Onth(Vector v);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles
{
    class Logical
    {
        bool v;
        public Logical(bool f)
        {
            v = f;
        }
        public void setLogical(bool f)
        {
            v = f;
        }
        public bool booleanValue()
        {
            return v;
        }
    }
}

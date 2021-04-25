using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles
{
    interface Comparador
    {
        bool igualQue(Object q);
        bool menorQue(object q);
        bool mayorQue(object q);
        bool menorQueId(object q);
        bool mayorQueId(object q);

        /*bool menorIgualQue(object q);
        
        bool mayorIgualQue(object q);*/
    }
}

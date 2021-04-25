using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles
{
    class Estudiante:Comparador

    {
        public String apellidos { get; set; }
        public String nombres { get; set; }
        public String email { get; set; }
        public String idEstudiante { get; set; }
        public int lab1 { get; set; }
        public int lab2 { get; set; }
        public int lab3 { get; set; }
        public int lab4 { get; set; }

        public Estudiante(string idEstudiante, string nombres, string apellidos, string email, int lab1, int lab2, int lab3, int lab4)
        {
            this.idEstudiante = idEstudiante;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.email = email;
            this.lab1 = lab1;
            this.lab2 = lab2;
            this.lab3 = lab3;
            this.lab4 = lab4;
        }

        bool Comparador.igualQue(object q)
        {
            Estudiante estudianteAux = (Estudiante)q;
            return email == estudianteAux.email;
        }
        bool Comparador.menorQue(object q)
        {
            Estudiante estudianteAux = (Estudiante)q;
            return (email.CompareTo(estudianteAux.nombres) < 0);           
        }
        bool Comparador.mayorQue(object q)
        {
            Estudiante estudianteAux = (Estudiante)q;
            return (email.CompareTo(estudianteAux.nombres) > 0);
        }
        bool Comparador.menorQueId(object q)
        {
            Estudiante estudianteAux = (Estudiante)q;
            return (idEstudiante.CompareTo(estudianteAux.idEstudiante) < 0);
        }
        bool Comparador.mayorQueId(object q)
        {
            Estudiante estudianteAux = (Estudiante)q;
            return (idEstudiante.CompareTo(estudianteAux.idEstudiante) > 0);
        }

        public override string ToString()
        {
            return idEstudiante+ " " + nombres + " " +apellidos +"; ";
        }

    }
}

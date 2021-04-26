using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles
{
    class Estudiante : Comparador

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
            Console.WriteLine("Comparing igual que: " + email + " - " + estudianteAux.email +
                "Valor: " + email.CompareTo(estudianteAux.email));
            return email == estudianteAux.email;
        }
        bool Comparador.menorQue(object q)
        {
            Estudiante estudianteAux = (Estudiante)q;
            Console.WriteLine("Comparing menor que: " + email + " - " + estudianteAux.email + 
                "Valor: "+email.CompareTo(estudianteAux.email));
            return (email.CompareTo(estudianteAux.email) < 0);
        }
        bool Comparador.mayorQue(object q)
        {
            Estudiante estudianteAux = (Estudiante)q;
            Console.WriteLine("Comparing mayor que: " + email + " - " + estudianteAux.email +
                "Valor: " + email.CompareTo(estudianteAux.email));
            return (email.CompareTo(estudianteAux.email) > 0);
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

        public string datoOrden()
        {
            return idEstudiante + " " + nombres + " " + apellidos+ "; ";

        }

        public override string ToString()
        {
            return idEstudiante + " " + nombres + " " + apellidos + "; ";
        }

        public string ToString(string i)
        {
            return idEstudiante + " " + nombres + " " + apellidos + "; ";
        }

    }
}

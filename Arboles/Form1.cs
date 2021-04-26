using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arboles
{
    public partial class Form1 : Form
    {
        bool existeArchivo = false;
        ArbolAVL arbolEstudiantes = new ArbolAVL();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            int counter = 0;
            string line = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {             

                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    existeArchivo = true;
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    System.IO.StreamReader file = new StreamReader(filePath);
                    char delimiter = ',';
                    string headerLine = file.ReadLine();
                    while ((line = file.ReadLine()) != null)
                    {
                        //Apellidos,Nombre,Email,IDEstudiante,Laboratorio1,Laboratorio2,Laboratorio3,Laboratorio4
                        String[] subString = line.Split(delimiter);
                        Estudiante nuevoEstudiante = new Estudiante(subString[3], subString[1], subString[0],
                            subString[2], Convert.ToInt32(subString[4]), Convert.ToInt32(subString[5]), 
                            Convert.ToInt32(subString[6]), Convert.ToInt32(subString[7]));
                        Console.WriteLine(subString[3] + " " + subString[1] + " " + subString[0] + " " +
                            subString[2] + " " + Convert.ToInt32(subString[4]) + " " + Convert.ToInt32(subString[5]) + " " +
                            Convert.ToInt32(subString[6]) + " " + Convert.ToInt32(subString[7]));

                        arbolEstudiantes.insertar(nuevoEstudiante);
                        counter++;
                    }

                    file.Close();
                }
            }

            NombreArchivo.Text = filePath.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (existeArchivo!=false)
            {
                try
                {
                    arbolEstudiantes.contadorNodosRecorridos = 0;
                    Estudiante estudianteBuscado = new Estudiante("", "", "", emailTextBox.Text, 0, 0, 0, 0);
                    Estudiante objectEstudianteEncontrado = (Estudiante)arbolEstudiantes.buscar(estudianteBuscado).valorNodo();
                    textBoxNombre.Text = objectEstudianteEncontrado.nombres;
                    textBoxApellido.Text = objectEstudianteEncontrado.apellidos;
                    textBoxId.Text = objectEstudianteEncontrado.idEstudiante;
                    textBoxLab1.Text = Convert.ToString(objectEstudianteEncontrado.lab1);
                    textBoxLab2.Text = Convert.ToString(objectEstudianteEncontrado.lab2);
                    textBoxLab3.Text = Convert.ToString(objectEstudianteEncontrado.lab3);
                    textBoxLab4.Text = Convert.ToString(objectEstudianteEncontrado.lab4);
                    textBoxPromedio.Text = Convert.ToString((objectEstudianteEncontrado.lab1 + objectEstudianteEncontrado.lab2 + objectEstudianteEncontrado.lab3 + objectEstudianteEncontrado.lab4) / 4);
                    if (Convert.ToInt32(textBoxPromedio.Text) >= 6)
                        textBoxResultado.Text = "Aprovado";
                    else
                        textBoxResultado.Text = "Reprovado";
                    MessageBox.Show("Se recorrrio "+ arbolEstudiantes.contadorNodosRecorridos+ " Nodo(s) para encontrar al estudiante.", "Nodos Recorridos", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encontro ningun resultado para la busqueda.", "Buscar", MessageBoxButtons.OK);
                }
                

            }
            else
                MessageBox.Show("Debe cargar un archivo para poder realizar la busqueda.", "Error: No existe archivo" , MessageBoxButtons.OK);

        }

        private void limpiarEntradas()
        {
            emailTextBox.Text = "";
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxId.Text = "";
            textBoxLab1.Text = "";
            textBoxLab2.Text = "";
            textBoxLab3.Text = "";
            textBoxLab4.Text = "";
            textBoxPromedio.Text = "";
            textBoxResultado.Text = "";
            emailTextBox.Select();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            limpiarEntradas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pre orden
            textBoxOrden.Text = "";
            textBoxOrden.Text = ArbolAVL.preOrden(arbolEstudiantes.raizArbol());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //post orden
            textBoxOrden.Text = "";
            textBoxOrden.Text = ArbolAVL.postOrden(arbolEstudiantes.raizArbol());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //en orden
            textBoxOrden.Text = "";
            textBoxOrden.Text = ArbolAVL.inOrden(arbolEstudiantes.raizArbol());
        }
    }
}

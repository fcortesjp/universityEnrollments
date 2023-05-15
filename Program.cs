using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace universityEnrollments
{
    //Nombre del estudiante: Francisco Cortes
    //Grupo: 
    //Número y Texto del programa
    //Código Fuente: autoría propia
    class Student
    {
        // variables privadas con propiedades de Estudiante
        private string name;
        private string schoolProgram;
        private char formOfPayment;

        // Acceso publico a propieades
        public string Name
        {
            get
            {
                return name; // retorna nombre 
            }
            set
            {
                name = value; // guarda nombre
            }
        }

        public string SchoolProgram
        {
            get
            {
                return schoolProgram; // returna Programa
            }
            set
            {
                schoolProgram = value; // guarda Programa
            }
        }

        public char FormOfPayment
        {
            get
            {
                return formOfPayment; // returna forma De Pago
            }
            set
            {
                formOfPayment = value; // guarda forma De Pago
            }
        }
        class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

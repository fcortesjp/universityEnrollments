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
    class Enrollment
    {
        // variables privadas con propiedades de Matricula
        private string studentName;
        private int schoolProgram;
        private int formOfPayment;
        private double fullPayment;
        private double discount;
        private double netPayment;
        private int credits;

        // Acceso publico a propieades
        public string StudentName
        {
            get
            {
                return studentName; // retorna nombre 
            }
            set
            {
                studentName = value; // guarda nombre
            }
        }

        public int SchoolProgram
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

        public int FormOfPayment
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

        public double FullPayment 
        {
            get
            {
                return fullPayment; // return full pago
            }
            set 
            {
                fullPayment = value; //guarda full pago
            }
        }

        public double Discount
        {
            get
            {
                return discount; // retorna descuento
            }
            set
            {
                discount = value; // guarda descuento
            }
        }

        public double NetPayment
        {
            get
            {
                return netPayment; // retorna Pago neto
            }
            set
            {
                netPayment = value; // guarda pago neto
            }
        }

        public int Credits
        {
            get
            {
                return credits; // retorna Pago neto
            }
            set
            {
                credits = value; // guarda pago neto
            }
        }
    }
    class Program
    {
        //esta funcion captura el numero de matriculas a ingresar
        static public int getNumberOfEnrollments()
        {
            int numberOfEnrollments = 0;
            while (true)
            {
                Console.Write("Ingrese numero de estudiantes a matricular: ");
                string numberEnrollmentsStr = Console.ReadLine();

                // revise si el numero a matricular esta en blanco o nulo
                if (string.IsNullOrWhiteSpace(numberEnrollmentsStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: el numero no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el numero a matricular puede ser un numero entero
                bool canBeInt = int.TryParse(numberEnrollmentsStr, out numberOfEnrollments);
                if (canBeInt == false)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no es valido");
                    //regrese al inicio del loop
                    continue;
                }
                //revise si el numero es negativo o cero
                if (numberOfEnrollments <= 0)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no puede ser negativo o cero");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }

            return numberOfEnrollments;
        }

        //esta funcion asigna informacion de pago y creditos para cada matricula
        public struct paymentAndCredits
        {
            public int credits;
            public double discount;
            public double fullPayment;
            public double discounted;
            public double netPayment;  
        }
        public static paymentAndCredits getPaymentAndCredits(int schoolProgram,int formOfPayment)
        {
            //valor por credito
            double costPerCredit = 200000;
            //objeto a retornar
            paymentAndCredits paymentAndCredit = new paymentAndCredits();
            //segun el programa determine los creditos y el % de descuento aplicable si paga en efectivo
            switch (schoolProgram)
            {
                case 1:
                    // Ingeniería de sistemas
                    paymentAndCredit.credits = 20;
                    paymentAndCredit.discount = 0.18;
                    break;
                case 2:
                    // Psicología
                    paymentAndCredit.credits = 16;
                    paymentAndCredit.discount = 0.12;
                    break;
                case 3:
                    // Economía
                    paymentAndCredit.credits = 18;
                    paymentAndCredit.discount = 0.10;
                    break;
                case 4:
                    // Comunicación Social
                    paymentAndCredit.credits = 18;
                    paymentAndCredit.discount = 0.05;
                    break;
                case 5:
                    // Administración de Empresas
                    paymentAndCredit.credits = 20;
                    paymentAndCredit.discount = 0.15;
                    break;
            }
            // calcule pago completo
            paymentAndCredit.fullPayment = costPerCredit * paymentAndCredit.credits;
            // calculate descuento aplicable (si pago en efectivo) 
            if (formOfPayment == 1)
            {
                paymentAndCredit.discounted = paymentAndCredit.fullPayment * paymentAndCredit.discount;
            }
            else
            {
                paymentAndCredit.discounted = 0;
            }
            // calcule valor neto (con el descuento incluido si es aplicable)
            paymentAndCredit.netPayment = paymentAndCredit.fullPayment - paymentAndCredit.discounted;
            //returne los valores dentro de un objeto
            return paymentAndCredit;
        }

        //esta funcion obtiene la informacion de cada matricula y la guarda en un array
        static public Enrollment[] getEnrollmentInformation(int numberOfEnrollments)
        {
            //define el array para guardar matriculas
            Enrollment[] enrollmentArray = new Enrollment[numberOfEnrollments];

            //por cada matricula...
            for (int i = 0; i < enrollmentArray.Length; i++)
            {
                //creamos un objeto matricula
                Enrollment enr = new Enrollment();
                string studentName;
                int schoolProgramInt = 0;
                int formOfPaymentInt;
                
                //Nombre de Estudiante: obtencion y validacion
                while (true)
                {
                    Console.Write("Ingrese nombre del estudiante para matricula " + (i + 1) + ": ");
                    studentName = Console.ReadLine();

                    // revise si el nombre del estudiante esta en blanco o nulo
                    if (string.IsNullOrWhiteSpace(studentName))
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: el date no puede estar en blanco");
                        //regrese al inicio del loop
                        continue;
                    }
                    //  revise si el nombre es un numero o tiene digitos
                    if (studentName.Any(char.IsDigit))
                    {
                        //si es asi indique mensaje de error
                        Console.WriteLine("el dato no puede contener digitos");
                        //regrese al incio del loop
                        continue;
                    }
                    // si no hay problemas con la captura salga del loop
                    break;
                }

                //Numero del programa: obtencion y validacion
                while (true)
                {
                    //muestre el menu de opciones y pida al usuario que ingrese una de ellas
                    Console.Write("Ingrese el código del programa para matrícula " + (i + 1) + ":\n\n ");
                    Console.WriteLine("1: Ingeniería de sistemas");
                    Console.WriteLine("2: Psicología");
                    Console.WriteLine("3: Economía");
                    Console.WriteLine("4: Comunicación Social");
                    Console.WriteLine("5: Administración de Empresas");
                    string schoolProgramStr = Console.ReadLine();

                    // revise si el dato ingresado esta en blanco o nulo
                    if (string.IsNullOrWhiteSpace(schoolProgramStr))
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: el date no puede estar en blanco");
                        //regrese al inicio del loop
                        continue;
                    }
                    //revise si el dato es un entero
                    bool canBeInt = int.TryParse(schoolProgramStr, out schoolProgramInt);
                    if (canBeInt == false)
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("El dato ingresado no es valido");
                        //regrese al inicio del loop
                        continue;
                    }
                    //revise que el codigo es un numero entre 1 y 5
                    if (schoolProgramInt >= 1 && schoolProgramInt <= 5)
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: El dato debe ser un numero entre 1 y 5");
                        //regrese al inicio del loop
                        continue;
                    }
                    // si no hay problemas con la captura salga del loop
                    break;
                }

                //forma de pago: obtencion y validacion
                while (true)
                {
                    //muestre el menu de opciones y pida al usuario que ingrese una de ellas
                    Console.Write("Ingrese la forma de pago " + (i + 1) + ":\n\n ");
                    Console.WriteLine("1: Efectivo");
                    Console.WriteLine("2: En Linea");
                    string formOfPaymentStr = Console.ReadLine();

                    // revise si el dato ingresado esta en blanco o nulo
                    if (string.IsNullOrWhiteSpace(formOfPaymentStr))
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: el date no puede estar en blanco");
                        //regrese al inicio del loop
                        continue;
                    }
                    //revise si el dato es un entero
                    bool canBeInt = int.TryParse(formOfPaymentStr, out formOfPaymentInt);
                    if (canBeInt == false)
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("El dato ingresado no es valido");
                        //regrese al inicio del loop
                        continue;
                    }
                    //revise que el codigo es un numero 1 o 2
                    if (formOfPaymentInt >= 1 && schoolProgramInt <= 2)
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: El dato debe ser 1 o 2");
                        //regrese al inicio del loop
                        continue;
                    }
                    // si no hay problemas con la captura salga del loop
                    break;
                }

                //asigne el nombre y la edad validada al objeto empleado creado
                enr.StudentName = studentName;
                enr.SchoolProgram = schoolProgramInt;
                enr.FormOfPayment = formOfPaymentInt;


                //guarde el objeto empleado en el array;
                enrollmentArray[i] = enr;
            }
            return enrollmentArray;
        }
        static void Main(string[] args)
        {
            //indique que hace el programa
            Console.Write("Este programa permite el ingreso de matriculas y hace un calculo con la info ingresada\n\n");

            //obtenga el numero de matriculas
            int numberOfEnrollments = getNumberOfEnrollments();
        }
    }
}

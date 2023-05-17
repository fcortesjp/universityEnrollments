using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace universityEnrollments
{
    //Nombre del estudiante: Francisco Cortes
    //Grupo: 213022_268
    //Número del Problema: 1
    //Código Fuente: autoría propia
    class Enrollment
    {
        // variables privadas con propiedades de Matricula
        private string studentName;
        private int schoolProgram;
        private int formOfPayment;
        private double fullPayment;
        private double discount;
        private double discounted;
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

        public double Discounted
        {
            get
            {
                return discounted; // retorna descuento
            }
            set
            {
                discounted = value; // guarda descuento
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
                    Console.WriteLine("1: Ingeniería de sistemas");
                    Console.WriteLine("2: Psicología");
                    Console.WriteLine("3: Economía");
                    Console.WriteLine("4: Comunicación Social");
                    Console.WriteLine("5: Administración de Empresas");
                    Console.Write("Ingrese el código del programa para matrícula " + (i + 1) + ": ");
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
                    //revise si el codigo es menor de 1 o mayor 5
                    if (schoolProgramInt < 1 || schoolProgramInt > 5)
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
                    Console.WriteLine("1: Efectivo");
                    Console.WriteLine("2: En Linea");
                    Console.Write("Ingrese la forma de pago " + (i + 1) + ": ");
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
                    //revise que el codigo es menor que 1 o mayor que 2
                    if (formOfPaymentInt < 1 || formOfPaymentInt > 2)
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
                paymentAndCredits data = getPaymentAndCredits(schoolProgramInt, formOfPaymentInt);
                enr.Credits = data.credits;
                enr.Discount = data.discount;
                enr.FullPayment = data.fullPayment;
                enr.Discounted = data.discounted;
                enr.NetPayment = data.netPayment;

                //guarde el objeto empleado en el array;
                enrollmentArray[i] = enr;
            }
            return enrollmentArray;
        }

        // esta funcion obtiene totales despues de iterar por todos los record de matriculas
        public static void getTotals(Enrollment[] enrArray) 
        {
            //acumuladores
            //Cantidad de estudiantes inscritos por programa académico.
            int totalEnrSystEng = 0;
            int totalEnrPsi = 0;
            int totalEnrEco = 0;
            int totalEnrSocCom = 0;
            int totalEnrBusMan = 0;
            //Total de créditos inscritos en el tercer período académico del 2020.
            int totalCredits = 0;
            //Valor total pagado por los estudiantes sin tener en cuenta el descuento.
            double totalFullPayment = 0.0;
            //Valor total de descuentos aplicados por la universidad a los estudiantes.
            double totalDiscounted = 0.0;
            //Valor neto de las inscripciones del primer semestre del 2020.
            double totalNetPayment = 0.0;

            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (Enrollment enr in enrArray)
            {
                Console.WriteLine(enr.StudentName + "\t" + enr.SchoolProgram + "\t" + enr.FormOfPayment + "\t" + enr.Discount + "\t" + enr.FullPayment + "\t" + enr.Discounted + "\t" + enr.NetPayment);
                
                switch (enr.SchoolProgram)
                {
                    case 1:
                        // Ingeniería de sistemas
                        totalEnrSystEng++;
                        break;
                    case 2:
                        // Psicología
                        totalEnrPsi++;
                        break;
                    case 3:
                        // Economía
                        totalEnrEco++;
                        break;
                    case 4:
                        // Comunicación Social
                        totalEnrSocCom++;
                        break;
                    case 5:
                        // Administración de Empresas
                        totalEnrBusMan++;
                        break;
                }
                //total de creditos
                totalCredits = totalCredits + enr.Credits;
                //total pago sin descuento
                totalFullPayment = totalFullPayment + enr.FullPayment;
                //total descontado
                totalDiscounted = totalDiscounted + enr.Discounted;
                //Total Neto Pagado (con el descuento aplicado)
                totalNetPayment = totalNetPayment + enr.NetPayment;
            }
            Console.WriteLine("--------------------------------------------------------------------------");
            //Muestre resultados
            Console.WriteLine("\n\n");
            Console.WriteLine("***********************Resultados***************************");
            Console.WriteLine("* Total De matriculas por Programa:");
            Console.WriteLine("  - Ingenieria de Sistemas: " + totalEnrSystEng);
            Console.WriteLine("  - Psicologia: " + totalEnrPsi);
            Console.WriteLine("  - Economia: " + totalEnrEco);
            Console.WriteLine("  - Comunicacion Social: " + totalEnrSocCom);
            Console.WriteLine("  - Administracion de Empresas: " + totalEnrBusMan);
            Console.WriteLine("* Total de Creditos: " + totalCredits);
            Console.WriteLine("* Total Pago sin descuentos: " + totalFullPayment);
            Console.WriteLine("* Total Descontado: " + totalDiscounted);
            Console.WriteLine("* Total Neto Pagado (con Descuento Aplicado): " + totalNetPayment);
            Console.WriteLine("************************************************************");
        }

        static void Main(string[] args)
        {
            //indique que hace el programa
            Console.Write("Este programa permite el ingreso de matriculas y hace un calculo con la info ingresada\n\n");

            //obtenga el numero de matriculas
            int numberOfEnrollments = getNumberOfEnrollments();

            //obtenga informacion de matriculas
            Enrollment[] enrollmentArray = getEnrollmentInformation(numberOfEnrollments);

            getTotals(enrollmentArray);
            //salga del programa despues de ejecucion finalizada
            Console.WriteLine("Presione enter para finalizar...");
            Console.ReadLine();
        }
    }
}

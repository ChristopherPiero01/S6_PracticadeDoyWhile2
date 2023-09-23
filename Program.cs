using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        //declarar variables
        public static double Va; //valor actual del credito
        public static double TasaIntAnual; //tasa de interes anual
        public static int tiempo; //tiempo del credito
        public static int tmeses; //tiempo en meses del credito
        public static int periodo; //periodo de la amortizacion
        public static double tasaMensual; //tasa de interes mensual
        public static double pago; //pago de la cuota del prestamo
        public static double factor1; // factor1 ayuda a la conversion de la tasa anual a mensual
        public static double factor2; //factor2 ayuda a la coneversio de ala tasa anual a mensual
        public static double Interes; //interes del credito 
        public static double amortizacion; //amortizacion del credito
        public static double tAmortizacion; //total de amortzacion
        public static double tInteres; //Total de interes
        public static double tmConv; //tasa mensual convertida
        static void Main(string[] args)
        {
            string espacio = " ";
            Console.Clear();
            Console.WriteLine("Amortización de crédito hipotecario");
            Console.WriteLine("===================================");
            //validar el monto actual del credito
            do
            {
                Console.WriteLine("Monto actual del credito: ");
                Va = double.Parse(Console.ReadLine());
                if (Va <= 0)
                    Console.WriteLine("Monto actuak del credito mayor a cero...!");
            } while (Va <= 0);
            //validar la tasa de interes
            do
            {
                Console.WriteLine("Tasa de interes anual: ");
                TasaIntAnual = double.Parse(Console.ReadLine());
                if (TasaIntAnual <= 0)
                    Console.WriteLine("Tasa de Interes anual mayor a cero");
            } while (TasaIntAnual <= 0);
            //validar el tiempo
            do
            {
                Console.Write("Tiempo anual:");
                tiempo = int.Parse(Console.ReadLine());
                if (tiempo <= 0)
                    Console.WriteLine("Tiempo Anual mayor a cero...!");
            } while (tiempo <= 0);
            //convertir la tasa de interes anual a mensual
            factor1 = 1 + (TasaIntAnual / 100);
            factor2 = 1.00 / 12.00; //periodo de tiempo de amortizacion mensual
            tasaMensual = Math.Pow(factor1, factor2);
            //convertir  el tiempo de años a meses
            tmeses = tiempo * 12;
            //calcular la amortizacion
            pago = (Va * tasaMensual) / (1 - Math.Pow((1 + tasaMensual), (tmeses * -1)));
            //tasa mensal convertida
            tmConv = tasaMensual * 100;
            Console.Write("Tasa de interés mensual: "+ tmConv.ToString("N2")+ "%");
            Console.WriteLine("Pago mensual         "+ pago.ToString("N2"));
            Console.Write("Periodo Mensual");
            Console.Write("{0,15}", "Valor Actual");
            Console.Write("{0,15}", "Interes");
            Console.Write("{0,15}", "Amortización");
            Console.Write("{0,15}", "Pago Mensual");
            Console.Write("\n"); //salto de linea
            Console.Write("********************************************************");
            Console.Write("********************************************************");
            Console.Write("\n"); //salto de linea
            periodo = 0;
            tAmortizacion = 0;
            do
            {
                periodo++; //incrementar en 1 el periodo
                //calcular el interes
                Interes = Va * tasaMensual;
                //calcular el ttal de interes
                tInteres += Interes;
                //calcular la amortizacion del credito
                amortizacion = pago - Interes;
                //sumar las amortizaciones
                tAmortizacion += amortizacion;
                //mostrar resultados tabulados
                Console.Write("{0}{1}", espacio.PadRight(7, ' '), periodo.ToString().PadLeft(2, ' '));
                Console.Write("{0}{1}", espacio.PadRight(7, ' '), Va.ToString().PadLeft(10, ' '));
                Console.Write("{0}{1}", espacio.PadRight(7, ' '), Interes.ToString().PadLeft(10, ' '));
                Console.Write("{0}{1}", espacio.PadRight(7, ' '), amortizacion.ToString().PadLeft(10, ' '));
                Console.Write("{0}{1}", espacio.PadRight(7, ' '), pago.ToString().PadLeft(10, ' '));
                Console.Write("\n"); //salto de linea
                //actualizar el valor del prestamo
                Va = Va - amortizacion;
            } while (periodo < tmeses);
            Console.WriteLine("Total de amortización pagada: " + tAmortizacion.ToString("N2"));
            Console.WriteLine("Total de interes pagado: " + tInteres.ToString("N2"));
            Console.WriteLine("\n"); //salto delinea
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOrdinario
{
    internal class Program
    {
        public enum Menu
        {
            ConsultarSaldo = 1, Depositar, Retirar, HistorialDepositos, HistorialRetiros, Salir
        }
        static double saldo = 0;
        static Dictionary<DateTime, double> Depositos = new Dictionary<DateTime, double>();
        static Dictionary<DateTime, double> Retiros = new Dictionary<DateTime, double>();

        static void Main(string[] args)
        {
            int intentos = 3;
            do
            {
                if (login())
                {
                    Console.WriteLine("Bienvenido a tu banco.");
                    while (true)
                    {
                        switch (Men())
                        {
                            case Menu.ConsultarSaldo:
                                Console.WriteLine($"Tu saldo es de: {saldo}.");
                                break;
                            case Menu.Depositar:
                                Console.WriteLine("Introduce la cantidad a depositar: ");
                                double deposito = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine($"Has depositado {deposito}");
                                break;
                            case Menu.Retirar:
                                Console.WriteLine("Introduce la cantidad a retirar: ");
                                double retiro = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine($"Has retirado {retiro}");
                                break;
                            case Menu.HistorialDepositos:

                                break;
                            case Menu.HistorialRetiros:

                                break;
                            case Menu.Salir:
                                Console.WriteLine("Gracias por usar nuestro servicio.");
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    intentos--;
                    Console.WriteLine($"Fallaste te quedan {intentos}");
                }
                if (intentos == 0)
                {
                    Console.WriteLine("Has fallado demasiadas veces, el programa se cerrará.");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            }
            while (intentos >= 0);
        }

        static bool login()
        {
            Console.WriteLine("Introduce tu usuario: ");
            string usuario = Console.ReadLine();
            Console.WriteLine("Introduce tu contraseña: ");
            string contrasena = Console.ReadLine();
            DateTime fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (usuario == "diego" && contrasena == "1234" && edad >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        static Menu Men()
        {
            Console.WriteLine("1) Consultar saldo actual");
            Console.WriteLine("2) Depositar dinero");
            Console.WriteLine("3) Retirar dinero");
            Console.WriteLine("4) Consultar historial de depósito");
            Console.WriteLine("5) Consultar historial de retiros");
            Console.WriteLine("6) Salir");
            Console.Write("Selecciona una opción: ");
            Menu opc = (Menu)Convert.ToInt32(Console.ReadLine());
            return opc;
        }
    }
}


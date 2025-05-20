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
        static Dictionary<DateTime, double> HistorialDepositos = new Dictionary<DateTime, double>();
        static Dictionary<DateTime, double> HistorialRetiros = new Dictionary<DateTime, double>();

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
                               
                                break;
                            case Menu.Retirar:
                               
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
            Console.WriteLine("Dame tu fecha de nacimiento:");
            DateTime fecha = Convert.ToDateTime(Console.ReadLine());
            DateTime fechaActual = DateTime.Now;
            int años = fechaActual.Year - fecha.Year;
            if (usuario == "diego" && contrasena == "1234" )
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
        static double LeerDinero(string mensaje) 
        {
            Console.WriteLine(mensaje);
            double cantidad = Convert.ToDouble(Console.ReadLine());
            return cantidad;
        }
        static void Comprobante(string tipo, double Dinero) 
        {
            Console.WriteLine("¡Quieres que enviemos un comprobante por correo? (s/n):");
            string respuesta = Console.ReadLine();
            if (respuesta == "s" || respuesta == "S")
            {
                Console.WriteLine($"Se ha enviado un comprobante de {tipo} por ${Dinero}");
            }
            else
            {
                Console.WriteLine("No se envio ningun correo");
            }
        }
        static void DepositarDinero() 
        {
            double dinero = LeerDinero("Ingresa dinero a depositar: ");
            saldo += dinero;
            HistorialDepositos.Add(DateTime.Now, dinero);
            Console.WriteLine("Correcto deposito");
            Comprobante("Deposito", dinero);
        }
    }
}


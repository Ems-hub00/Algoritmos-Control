using System;

class Program
{
    static void Main()
    {
        // VARIABLES
        int pinCorrecto = 2907;
        int pinIngresado;
        int intentos = 3;
        int opcion = 0;

        double saldo = 15500;
        double deposito;
        double retiro;
        double totalDepositado = 0;

        bool acceso = false;

        // VALIDACION DEL PIN
        while (intentos > 0 && acceso == false)
        {
            Console.Write("Ingrese su PIN: ");
            pinIngresado = int.Parse(Console.ReadLine());

            if (pinIngresado == pinCorrecto)
            {
                Console.WriteLine("PIN correcto. Bienvenido.");
                acceso = true;
            }
            else
            {
                intentos--;
                Console.WriteLine("PIN incorrecto.");
                Console.WriteLine("Intentos restantes: " + intentos);
            }
        }

        // BLOQUEO DE CUENTA
        if (acceso == false)
        {
            Console.WriteLine("Cuenta bloqueada.");
        }
        else
        {
            // MENU PRINCIPAL
            do
            {
                Console.WriteLine("\n===== MENU BANCARIO =====");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Retirar");
                Console.WriteLine("4. Salir");

                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Saldo actual: RD$ " + saldo);
                        break;

                    case 2:
                        Console.Write("Ingrese el monto a depositar: ");
                        deposito = double.Parse(Console.ReadLine());

                        if (deposito > 0)
                        {
                            saldo = saldo + deposito;
                            totalDepositado = totalDepositado + deposito;

                            Console.WriteLine("Depósito realizado correctamente.");
                            Console.WriteLine("Nuevo saldo: RD$ " + saldo);
                        }
                        else
                        {
                            Console.WriteLine("El depósito debe ser mayor que cero.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese el monto a retirar: ");
                        retiro = double.Parse(Console.ReadLine());

                        if (retiro > 0 && retiro <= saldo && retiro % 100 == 0)
                        {
                            saldo = saldo - retiro;

                            Console.WriteLine("Retiro realizado correctamente.");
                            Console.WriteLine("Nuevo saldo: RD$ " + saldo);
                        }
                        else
                        {
                            Console.WriteLine("Retiro inválido.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }

            } while (opcion != 4);

            // RESULTADO FINAL
            Console.WriteLine("\n===== RESUMEN =====");
            Console.WriteLine("Saldo final: RD$ " + saldo);
            Console.WriteLine("Total depositado: RD$ " + totalDepositado);
        }
    }
}
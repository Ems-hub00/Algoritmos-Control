using System;

class Program
{
    static void Main(string[] args)
    {
        string respuesta = "S";

        while (respuesta == "S")
        {
            Console.WriteLine();
            Console.WriteLine("=== SIMULADOR DE PRESTAMO ===");

            // ----- Pedir monto -----
            double monto = 0;
            bool montoValido = false;
            while (!montoValido)
            {
                Console.Write("Monto (5000 a 500000): ");
                string textoMonto = Console.ReadLine();
                double valorMonto;
                bool ok = double.TryParse(textoMonto, out valorMonto);
                if (ok && valorMonto >= 5000 && valorMonto <= 500000)
                {
                    monto = valorMonto;
                    montoValido = true;
                }
                else
                {
                    Console.WriteLine("Monto invalido. Intente de nuevo.");
                }
            }

            // ----- Pedir plazo -----
            int plazo = 0;
            bool plazoValido = false;
            while (!plazoValido)
            {
                Console.Write("Plazo en meses (6 a 60): ");
                string textoPlazo = Console.ReadLine();
                int valorPlazo;
                bool ok = int.TryParse(textoPlazo, out valorPlazo);
                if (ok && valorPlazo >= 6 && valorPlazo <= 60)
                {
                    plazo = valorPlazo;
                    plazoValido = true;
                }
                else
                {
                    Console.WriteLine("Plazo invalido. Intente de nuevo.");
                }
            }

            // ----- Pedir categoria -----
            double tasaAnual = 0;
            bool categoriaValida = false;
            while (!categoriaValida)
            {
                Console.Write("Categoria del socio (A, B o C): ");
                string categoria = Console.ReadLine();
                if (categoria == null)
                {
                    categoria = "";
                }
                categoria = categoria.Trim().ToUpper();

                if (categoria == "A")
                {
                    tasaAnual = 0.12;
                    categoriaValida = true;
                }
                else if (categoria == "B")
                {
                    tasaAnual = 0.15;
                    categoriaValida = true;
                }
                else if (categoria == "C")
                {
                    tasaAnual = 0.18;
                    categoriaValida = true;
                }
                else
                {
                    Console.WriteLine("Categoria invalida. Intente de nuevo.");
                }
            }

            // ----- Calculo de la cuota -----
            double i = tasaAnual / 12;
            double factor = Math.Pow(1 + i, plazo);
            double cuota = monto * (i * factor) / (factor - 1);
            cuota = Math.Round(cuota, 2);

            Console.WriteLine();
            Console.WriteLine("Monto:         RD$ " + monto.ToString("N2"));
            Console.WriteLine("Plazo:         " + plazo + " meses");
            Console.WriteLine("Tasa anual:    " + (tasaAnual * 100) + " %");
            Console.WriteLine("Cuota mensual: RD$ " + cuota.ToString("N2"));
            Console.WriteLine();
            Console.WriteLine("TABLA DE AMORTIZACION");
            Console.WriteLine("Mes".PadRight(5) + "Cuota".PadLeft(14) + "Interes".PadLeft(14) + "Abono capital".PadLeft(16) + "Saldo".PadLeft(16));
            Console.WriteLine(new string('-', 65));

            // ----- Tabla de amortizacion -----
            double saldoPendiente = monto;
            double totalPagado = 0;
            double totalIntereses = 0;

            for (int mes = 1; mes <= plazo; mes++)
            {
                double interes = Math.Round(saldoPendiente * i, 2);
                double cuotaMes = cuota;
                double abono = cuotaMes - interes;

                if (mes == plazo)
                {
                    abono = saldoPendiente;
                    cuotaMes = abono + interes;
                }

                saldoPendiente = Math.Round(saldoPendiente - abono, 2);
                totalPagado = totalPagado + cuotaMes;
                totalIntereses = totalIntereses + interes;

                Console.WriteLine(
                    mes.ToString().PadRight(5) +
                    cuotaMes.ToString("N2").PadLeft(14) +
                    interes.ToString("N2").PadLeft(14) +
                    abono.ToString("N2").PadLeft(16) +
                    saldoPendiente.ToString("N2").PadLeft(16));
            }

            Console.WriteLine(new string('-', 65));
            Console.WriteLine("Total pagado:       RD$ " + totalPagado.ToString("N2"));
            Console.WriteLine("Total de intereses: RD$ " + totalIntereses.ToString("N2"));

            // ----- Repetir? -----
            Console.WriteLine();
            Console.Write("Desea simular otro prestamo? (S/N): ");
            respuesta = Console.ReadLine();
            if (respuesta == null)
            {
                respuesta = "N";
            }
            respuesta = respuesta.Trim().ToUpper();
        }

        Console.WriteLine("Gracias por usar el sistema.");
    }
}

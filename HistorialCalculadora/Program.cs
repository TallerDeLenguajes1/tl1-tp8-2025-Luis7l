using CalculadoraHistorial;
internal class Program
{
    private static void Main()
    {
        List<Operacion> Historial = new List<Operacion>();
        int opcion;
        do
        {
            Console.WriteLine("Indique con el numero indicado la operacion que quiere realizar");
            Console.WriteLine("1-Suma");
            Console.WriteLine("2-Resta");
            Console.WriteLine("3-Multiplicacion");
            Console.WriteLine("4-Divisicion");
            Console.WriteLine("5-Limpiar");
            Console.WriteLine("6-Ver historial");
            Console.WriteLine("7-Ver resultado");
            Console.WriteLine("8-Salir");
            string input = Console.ReadLine() ?? "";
            opcion = int.TryParse(input, out opcion) ? opcion : 0;
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Indique el valor a sumar");
                    double valorSuma = double.Parse(Console.ReadLine() ?? "0");
                    Operacion suma = new Operacion(Historial, TipoOperacion.Suma, valorSuma);
                    suma.RealizarOperacion();
                    break;
                case 2:
                    Console.WriteLine("Indique el valor a restar");
                    double valorResta = double.Parse(Console.ReadLine() ?? "0");
                    Operacion resta = new Operacion(Historial, TipoOperacion.Resta, valorResta);
                    resta.RealizarOperacion();
                    break;
                case 3:
                    Console.WriteLine("Indique el valor a multiplicar");
                    double valorMultiplicacion = double.Parse(Console.ReadLine() ?? "0");
                    Operacion multiplicacion = new Operacion(Historial, TipoOperacion.Multiplicacion, valorMultiplicacion);
                    multiplicacion.RealizarOperacion();
                    break;
                case 4:
                    Console.WriteLine("Indique el valor a dividir");
                    double valorDivision = double.Parse(Console.ReadLine() ?? "0");
                    Operacion division = new Operacion(Historial, TipoOperacion.Division, valorDivision);
                    division.RealizarOperacion();
                    break;
                case 5:
                    Console.WriteLine("Limpiando historial...");
                    Historial.Clear();
                    break;
                case 6:
                    Console.WriteLine("Historial de operaciones:");
                    foreach (var operacion in Historial)
                    {
                        Console.WriteLine($"- {operacion.TipoOperacion}: {operacion.Resultado}");
                    }
                    break;
                case 7:
                    if (Historial.Count > 0)
                    {
                        Console.WriteLine($"Último resultado: {Historial.Last().Resultado}");
                    }
                    else
                    {
                        Console.WriteLine("No hay operaciones en el historial.");
                    }
                    break;
            }
                
            // Validación de la opción
            if (opcion < 1 || opcion > 8)
            {
                Console.WriteLine("Opción no válida, por favor intente de nuevo.");
            }
        } while (opcion != 8);
    }
}
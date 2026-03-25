namespace TuringMachine;

public class Test
{
    static char empty = '☐';
    public static void Main(string[] args)
    {
        var option = new ConsoleKeyInfo();
        Turing machine = new Turing();

        //Contador.BuiltIn(ref machine);
        //Multiplicador.BuiltIn(ref machine);
        Divisor.BuiltIn(ref machine);
        Console.WriteLine("A: Escribir caso. " +
                          $"\nCualquier otra tecla: Evaluar varios casos");
        option = Console.ReadKey(true);
        Console.Clear();
        if (option.Key == ConsoleKey.A)
        {
            Console.WriteLine("Ingrese cadena a validar paso a paso");
            string input = Console.ReadLine()!;
            machine.NewInput(input);
            Console.WriteLine("Inicio:\tLectura:\tEscritura:\tCabezal Dir\tDestino\tCinta");
            do
            {
                var info = machine.StepInfo();
                if (info.Item5 is null) continue;
                Console.Write($"{info.Item1}\t{info.Item2}\t\t{info.Item3}\t\t{info.Item4}\t\t{info.Item5}\t");
                string cinta = info.Item6;
                bool cabezal = false;
                foreach (var c in cinta)
                {
                    if (c == '[') cabezal = true;
                    if (cabezal) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ResetColor();
                    if(c == ']') cabezal = false;
                    Console.Write(c);
                }
                Console.WriteLine();
            } while (machine.Step() != "Rejected");
            Console.WriteLine($"State: {machine.EvaluateInput(input)} ");
            Console.WriteLine($"Result: {machine.GetCintaCabezal()}");
        }
        else
        {
            Console.WriteLine("Ingresa 0 para evaluar");
            string cabezal = "\nInput:\t\tStatus:\t\tResult\n";
            string? inp;
            List<string> output = new List<string>();
            output.Add(cabezal);
            output.Add("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            while ((inp = Console.ReadLine()!) != "0")
            {
                string add = $"{inp}\t\t" +
                                  $"{machine.EvaluateInput(inp)}\t\t" +
                                  $"{machine.GetCintaCabezal()}";
                output.Add(add);
            }
            Console.WriteLine(string.Join("\n", output));
        }
    }
}
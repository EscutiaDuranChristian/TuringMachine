namespace TuringMachine;

public class Test
{
    public static void Main(string[] args)
    {
        Turing machine = new Turing();
        string input = "11111";
        machine.AddState(); machine.AddState();

        machine.AddTransition(0, 0, '1', '0', 'R');
        machine.AddTransition(0, 1, '☐', '☐', 'L');
        machine.AddTransition(1, 1, '0', '0', 'L');


        machine.SetStarterState(0);
        machine.SetAceptationState(1);

        string res = machine.EvaluateInput(input);
        string cinta = machine.GetCinta();
        Console.WriteLine(cinta);
        Console.WriteLine(res);
    }
}
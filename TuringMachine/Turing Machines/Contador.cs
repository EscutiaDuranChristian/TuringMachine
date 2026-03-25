using TuringMachine;

public class Contador 
{
    static char empty = '☐';
    public static void BuiltIn(ref Turing machine)
    {
        for (int i = 0; i < 14; i++) machine.AddState();
        machine.AddTransition(0, 1, '0', empty, 'R');
        for (int i = 1; i < 10; i++)
        {
            char c = (char)(i + '0');
            machine.AddTransition(0, 1, c, c, 'R');
        }
        machine.AddTransition(1, 2, '=', '=', 'R');
        machine.AddTransition(2, 3, empty, empty, 'L');
        machine.AddTransition(3, 3, '=', '=', 'L');
        for (int i = 1; i < 10; i++)
        {
            char c = (char)(i + '0');
            char w = (char)(i - 1 + '0');
            machine.AddTransition(3, 4, c, w, 'R');
        }
        machine.AddTransition(4, 5, '=', '=', 'R');
        machine.AddTransition(5, 5, '1', '1', 'R');
        machine.AddTransition(5, 6, empty, '1', 'L');
        machine.AddTransition(6, 6, '1', '1', 'L');
        machine.AddTransition(6, 3, '=', '=', 'L');
        machine.AddTransition(3, 7, '0', empty, 'R');
        machine.AddTransition(7, 8, '=', empty, 'R');
        machine.AddTransition(8, 9, '1', '0', 'R');
        machine.AddTransition(9, 9, '1', '1', 'R');
        machine.AddTransition(9, 10, '=', '=', 'R');
        machine.AddTransition(9, 10, empty, '=', 'R');
        machine.AddTransition(10, 11, empty, '1', 'L');
        for (int i = 1; i < 9; i++)
        {
            char c = (char)(i + '0');
            char w = (char)(i + 1 + '0');
            machine.AddTransition(10, 11, c, w, 'L');
        }
        machine.AddTransition(11, 11, '1', '1', 'L');
        machine.AddTransition(11, 11, '=', '=', 'L');
        machine.AddTransition(11, 8, '0', '0', 'R');
        machine.AddTransition(8, 12, '=', '=', 'L');
        machine.AddTransition(12, 12, '0', '1', 'L');
        machine.AddTransition(12, 13, empty, empty, 'R');

        machine.SetStarterState(0);
        machine.SetAceptationState(13);
    }
}
using TuringMachine;

public class Multiplicador
{
    static char empty = '☐';
    public static void BuiltIn(ref Turing machine)
    {
        for (int i = 0; i < 13; i++) machine.AddState();

        machine.AddTransition(0, 1, '1', '1', 'R');

        machine.AddTransition(1, 1, '1', '1', 'R');
        machine.AddTransition(1, 2, 'x', 'x', 'R');
        
        machine.AddTransition(2, 2, '1', '1', 'R');
        machine.AddTransition(2, 3, '=', '=', 'R');

        machine.AddTransition(3, 4, empty, empty, 'L');

        machine.AddTransition(4, 4, '=', '=', 'L');
        machine.AddTransition(4, 4, '1', '1', 'L');
        machine.AddTransition(4, 4, 'x', 'x', 'L');
        machine.AddTransition(4, 5, '0', '0', 'R');
        machine.AddTransition(4, 5, empty, empty, 'R');

        machine.AddTransition(5, 6, '1', '0', 'R');
        machine.AddTransition(5, 11, 'x', 'x', 'L');

        machine.AddTransition(6, 6, '1', '1', 'R');
        machine.AddTransition(6, 7, 'x', 'x', 'R');

        machine.AddTransition(7, 7, '0', '0', 'R');
        machine.AddTransition(7, 8, '1', '0', 'R');
        machine.AddTransition(7, 10, '=', '=', 'L');

        machine.AddTransition(8, 8, '=', '=', 'R');
        machine.AddTransition(8, 8, '1', '1', 'R');
        machine.AddTransition(8, 9, empty, '1', 'L');

        machine.AddTransition(9, 9, '=', '=', 'L');
        machine.AddTransition(9, 9, '0', '0', 'L');
        machine.AddTransition(9, 9, '1', '1', 'L');
        machine.AddTransition(9, 6, 'x', 'x', 'S');

        machine.AddTransition(10, 10, '0', '1', 'L');
        machine.AddTransition(10, 4, 'x', 'x', 'L');

        machine.AddTransition(11, 11, '0', '1', 'L');
        machine.AddTransition(11, 12, empty, empty, 'R');

        machine.SetStarterState(0);
        machine.SetAceptationState(12);
    }
}
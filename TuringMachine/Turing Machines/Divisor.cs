namespace TuringMachine;

public class Divisor
{
    static char empty = '☐';
    public static void BuiltIn(ref Turing machine)
    {
        for (int i = 0; i < 15; i++) machine.AddState();

        machine.AddTransition(0, 1, '1', '1', 'R');

        machine.AddTransition(1, 1, '1', '1', 'R');
        machine.AddTransition(1, 2, '/', '/', 'R');

        machine.AddTransition(2, 2, '1', '1', 'R');
        machine.AddTransition(2, 3, '=', '=', 'R');

        machine.AddTransition(3, 4, empty, empty, 'L');

        machine.AddTransition(4, 4, '=', '=', 'L');
        machine.AddTransition(4, 4, '1', '1', 'L');
        machine.AddTransition(4, 5, '/', '/', 'R');

        machine.AddTransition(5, 5, '0', '0', 'R');
        machine.AddTransition(5, 9, '=', '=', 'R');
        machine.AddTransition(5, 6, '1', '0', 'L');

        machine.AddTransition(6, 6, '0', '0', 'L');
        machine.AddTransition(6, 6, '1', '1', 'L');
        machine.AddTransition(6, 7, '/', '/', 'L');

        machine.AddTransition(7, 7, '0', '0', 'L');
        machine.AddTransition(7, 8, '1', '0', 'R');
        machine.AddTransition(7, 11, empty, empty, 'R');

        machine.AddTransition(8, 8, '0', '0', 'R');
        machine.AddTransition(8, 5, '/', '/', 'R');

        machine.AddTransition(9, 9, '1', '1', 'R');
        machine.AddTransition(9, 10, empty, '1', 'L');

        machine.AddTransition(10, 10, '=', '=', 'L');
        machine.AddTransition(10, 10, '1', '1', 'L');
        machine.AddTransition(10, 10, '0', '1', 'L');
        machine.AddTransition(10, 5, '/', '/', 'R');

        machine.AddTransition(11, 11, '1', '1', 'R');
        machine.AddTransition(11, 11, '/', '/', 'R');
        machine.AddTransition(11, 11, '0', '1', 'R');
        machine.AddTransition(11, 12, '=', '=', 'R');

        machine.AddTransition(12, 14, '1', '1', 'L');
        machine.AddTransition(12, 14, empty, '0', 'L');

        machine.AddTransition(14, 14, '/', '/', 'L');
        machine.AddTransition(14, 14, '1', '1', 'L');
        machine.AddTransition(14, 14, '=', '=', 'L');
        machine.AddTransition(14, 13, empty, empty, 'R');

        machine.SetStarterState(0);
        machine.SetAceptationState(13);
    }
}
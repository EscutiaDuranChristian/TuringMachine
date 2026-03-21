using Cinta = System.Collections.Generic.List<char>;
using TuringMachine.Exceptions;

namespace TuringMachine;
public static class TuringHelper
{
    private static int stateID = 0;
    public static int StateID => stateID;
    public static char[] refill = {
        '☐', '☐', '☐', '☐'
    };

    public static State? AddState(State state)
    {
        if (state is not null)
            state.AssgignID(stateID++);
        return state;
    }
    /// <summary>
    /// Intenta resetear la maquina de turing
    /// </summary>
    /// <param name="current">El estado acutal, si start no es null va a tener
    ///                       sus caracteristicas
    ///  </param>
    /// <param name="start">El nodo inicial</param>
    /// <exception cref="NoStarterStateException">
    /// Se lanza cuando start == null
    /// </exception>
    public static void ResetTM(ref State? current, State? start)
    {
        if (start is not null)
            current = start;
        else throw new NoStarterStateException();
    }
    public static void MoveCabezal
        (char dir, ref int cabezal, ref Cinta cinta)
    {
        switch (dir)
        {
            case 'R': cabezal++; break;
            case 'L': cabezal--; break;
        }
        if (cabezal < 0)
        {
            cabezal = 3;
            cinta.InsertRange(0, refill);
        }
        else if (cabezal > cinta.Count) cinta.AddRange(refill);
    }
    public static void ResetTransitionInfo
        (ref char? write, ref char? dir, ref int? dest)
    {
        write = dir = null;
        dest = null;
    }
}
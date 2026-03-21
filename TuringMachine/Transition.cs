using TuringMachine.Interfaces;
namespace TuringMachine;
public class Transition : ITransition
{
    private int destino;
    private char read, write, direction; 
    public int Destino => destino; 
    public char Read => read;
    public char Write => write; 
    public char Direction => direction;
    public Transition(char read, char write, char dir, int des)
    {
        this.read = read;
        this.write = write;
        direction = dir;
        destino = des;
    }

    /// <summary>
    /// Toma el caracter de entrada y determina 
    /// si es posible viajar.
    /// </summary>
    /// <param name="read">el caracter de entrada</param>
    /// <returns><b>True</b> Si el input es igual input esperado
    /// <b>False si no es asi.</b>
    ///  Cuando retorna true, retorna tambien el char de escritura
    /// la direccion del cabezal y el estado al que va a viajar.
    /// <b>Item1: write. </b>
    /// <b>Item2: direction. </b>
    /// <b>Item3: destino. </b>
    /// </returns>
    public (bool, (char, char, int)?) CanTravel(char read)
    {
        if (read == this.Read)
            return (true, (Write, Direction, Destino));
        return (false, null);
    }
}
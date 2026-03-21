namespace TuringMachine.Exceptions; 

public class NoStarterStateException : Exception
{
    public NoStarterStateException() :
        base("~~There is no started state defined~~")
    { }
}
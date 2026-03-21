namespace TuringMachine.Interfaces;

public interface ITransition
{
    (bool, (char, char, int)?) CanTravel(char input);
    char Read { get; }
    char Write { get; }
    char Direction { get; }
    int Destino { get; }
}
using TuringMachine.Interfaces;
namespace TuringMachine;

public class State
{
    public Action<(char, char, int)> OnSuccesfullEnd;

    public int? ID { get; private set; } = null;
    public bool Aceptation { get; private set; }
    public void SetAceptation(bool acpt) => Aceptation = acpt;
    public List<ITransition> Transitions { get; private set; }

    public State(bool acpt = false)
    {
        Transitions = new List<ITransition>();
        SetAceptation(acpt);
    }
    public State(State state) : this(state.Aceptation) 
    {
        Transitions = new List<ITransition>(state.Transitions);
    }
    public void AddEvent(Action<(char, char, int)> @event) =>
        OnSuccesfullEnd += @event;

    public void StartEvent(char read)
    {
        (char,char,int)? result = null;
        
        foreach (var t in Transitions)
        {
           var canTravel = t.CanTravel(read);
           if (canTravel.Item1)
           {
                result = canTravel.Item2;
                break;
           }
        }

        if (result is not null) 
            OnSuccesfullEnd?.Invoke(result.Value);
    }

    public void AddTransition(ITransition t)
    {
        if (Transitions.Find(x => x.Read == t.Read) is null)
            Transitions.Add(t);
    }
    public void RemoveTransition(int idDest, char read)
    {
        Transitions.RemoveAll(x => x.Read == read && x.Destino == idDest);
    }

    public bool AssgignID(int id)
    {
        if (ID is null)
        {
            ID = id;
            return true;
        }
        return false;
    }
    public void RemoveAllTransitions(int state)
    {
        Transitions.RemoveAll(x => x.Destino == state);
    }
}
using Cinta = System.Collections.Generic.List<char>;
using TST = System.Collections.Generic.Dictionary<int, TuringMachine.State>;
using System.Text;

namespace TuringMachine;
public class Turing
{ 
    private TST states = new TST();
    private Cinta cinta = new Cinta();
    int cabezal = 0; 
    State? current = null, start = null;
    char? write, dir, read = null;
    int? dest, inicio = null, inicio2 = null;
    string initialCinta = string.Empty;

    #region Build Turing machine

    public void AddState()
    {
        var state = new State();
        states.Add(TuringHelper.StateID,
                   TuringHelper.AddState(state)!
        );
        state.AddEvent(((char, char, int) res) => {
            write = res.Item1;
            dir = res.Item2;
            dest = res.Item3;
        });
    }
    public void DeleteState(int id)
    {
        var state = states[id];
        foreach (var st in states.Values)
            st.RemoveAllTransitions(id);
        states.Remove(id);  
    }
    public void AddTransition(int idFrom, int idTo,
                              char read, char write, char dir)
    {
        var transition = new Transition(read, write, dir, idTo);
        states[idFrom].AddTransition(transition);
    }
    public void RemoveTransition(int idFrom, int idTo, char read) =>
        states[idFrom].RemoveTransition(idTo, read);
    public void SetStarterState(int id)
    {
        start = states[id];
        inicio = id;
        inicio2 = inicio;
    }
    public void SetAceptationState(int id) => states[id].SetAceptation(true);
    public void RemoveAceptationState(int id) => states[id].SetAceptation(false);

    #endregion

    #region MoveCabezal
    /// <summary>
    /// Recibe un nuevo input, puede lanzar NoStarterNodeException.
    /// Si el input, ya se habia definido, este se eliminara de la cinta y
    /// se agregara el nuevo input a la susodicha.
    /// </summary>
    /// <param name="input">El input que se va a ingresar a la cinta.</param>
    public void NewInput(string input)
        {
            TuringHelper.ResetTM(ref current, start);
            cinta.Clear();
            cabezal = 4;
            cinta = [.. $"☐☐☐☐{input}☐☐☐☐"];
        }
    public string GetCintaCabezal()
    {
            var result = new StringBuilder();
            for (int i = cabezal; i < cinta.Count; i++)
            {
                if (cinta[i] == '☐') return result.ToString();
                result.Append(cinta[i]);
            }
            return "";
    }
    public string GetCinta()
    {
        var result = new StringBuilder();
        for(int i = 0; i < cinta.Count; i++)
        {
            if (i == cabezal) 
                result.Append('[').Append(cinta[i]).Append(']');
            else result.Append(cinta[i]);
        }
        return result.ToString();
    }
    public string Step()
    {
        initialCinta = GetCinta();
        if (current is null) return "Rejected";
        TuringHelper.ResetTransitionInfo(ref write, ref dir, ref dest);
        current.StartEvent(cinta[cabezal]);
        if(dir is null) return "Rejected";
        inicio = inicio2;
        read = cinta[cabezal];
        cinta[cabezal] = (char)write!;
        TuringHelper.MoveCabezal((char)dir, ref cabezal, ref cinta);
        current = states[(int)dest!];
        inicio2 = dest;
        return "Acepted";
    }
    public (int?, char?, char?, char?, int?, string) StepInfo() => 
        (inicio, read, write, dir, dest, initialCinta);
    public string EvaluateInput(string input)
    {
        NewInput(input);
        while (Step() != "Rejected"){}
        if (current!.Aceptation) return "Acepted";
        cinta.Clear();
        return "Rejected";
    }
    public int Actual() => current?.ID ?? 0;
    #endregion
}
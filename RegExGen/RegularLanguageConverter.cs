using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    public class RegularLanguageConverter
    {
        public static string Convert(Automata a)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"G = (N, Σ, P, {a.startStates.First()})");
            sb.Append("N = { ");
            foreach (string s in a.states)
                if (a.states.Last().Equals(s))
                    sb.Append(s + " }");
                else
                    sb.Append($"{s},");
            sb.AppendLine();
            sb.Append("Σ = { ");
            foreach (char s in a.symbols)
                if (a.symbols.Last().Equals(s))
                    sb.Append(s + " }");
                else
                    sb.Append($"{s},");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("P :");
            Dictionary<string, List<string>> lines = new Dictionary<string, List<string>>();
            foreach (Transition t in a.transitions)
            {
                if (!lines.ContainsKey(t.fromState))
                    lines.Add(t.fromState, new List<string>());
                List<string> lt = lines[t.fromState];
                lt.Add($"{t.symbol}{t.toState}");
                if (a.finalStates.Contains(t.toState))
                    lt.Add(t.symbol.ToString());
                lines[t.fromState] = lt;
            }
            foreach (KeyValuePair<string, List<string>> kv in lines)
            {
                sb.Append(string.Format("{0,5} {1,4}", kv.Key, "-> "));
                foreach (string v in kv.Value) {
                    if (kv.Value.Last().Equals(v))
                        sb.Append(v);
                    else
                        sb.Append($"{v} | ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}

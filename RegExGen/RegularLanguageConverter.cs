using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    public class RegularLanguageConverter
    {
        public static string ConvertAutomataToLanguage(Automata a)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"G = (N, Σ, P, {a.startStates.First()})");
            sb.Append("N = {");
            foreach (string s in a.states)
                if (a.states.Last().Equals(s))
                    sb.Append(s + "}");
                else
                    sb.Append($"{s},");
            sb.AppendLine();
            sb.Append("Σ = {");
            foreach (char s in a.symbols)
                if (a.symbols.Last().Equals(s))
                    sb.Append(s + "}");
                else
                    sb.Append($"{s},");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("P =");
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

        public static Automata ConvertLanguageToAutomata(string language) {
            Automata automata = new Automata();

            string l = language.Trim().Replace("\r\n", "").Replace(" ", "");
            int iG = l.IndexOf('G');
            if (iG == -1)
                throw new Exception("G params missing");
            string g = l.Substring(l.IndexOf('(') + 1, l.IndexOf(')') - l.IndexOf('(') - 1);
            string[] param = g.Split(',');
            if (g.IndexOf('{') == -1) {
                automata.startStates.Add(param[3]);
            } else {
                string[] ss = g.Substring(g.IndexOf('{') + 1, l.IndexOf('}') - l.IndexOf('{') - 1).Split(',');
                foreach(string s in ss)
                    automata.startStates.Add(s);
            }
            int iN = l.IndexOf($"{param[0]}={{");
            if (iN == -1)
                throw new Exception($"First param {param[0]} (state collection) missing");
            int iΣ = l.IndexOf($"{param[1]}={{");
            if (iΣ == -1)
                throw new Exception($"Second param {param[1]} (symbols collection) missing");
            int iP = l.IndexOf($"{param[2]}={{");
            if (iP == -1)
                throw new Exception($"Third param {param[2]} (language rules) missing");

            //TODO: language

            //TODO: transitions

            return automata;
        }

    }
}

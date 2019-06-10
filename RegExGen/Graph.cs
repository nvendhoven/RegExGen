using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RegExGen
{
    public class Graph
    {
        public enum Type { NDFA, DFA, ODFA }

        public static string CreateImagePath(Type type, Automata automata)
        {
            StringBuilder dot = new StringBuilder();
            dot.AppendLine("digraph dfa {");
            dot.AppendLine("rankdir=LR;");

            dot.AppendLine("");

            dot.AppendLine("NOTHING [label=\"\", shape=none]");
            foreach (string state in automata.states)
            {
                if (automata.startStates.Contains(state) && automata.finalStates.Contains(state))
                    dot.AppendLine($"{state} [label=\"{state}\" shape=ellipse, peripheries=2, style=filled, color=yellowgreen]");
                else if (automata.startStates.Contains(state))
                    dot.AppendLine($"{state} [label=\"{state}\" shape=ellipse, style=filled, color=lightblue]");
                else if (automata.finalStates.Contains(state))
                    dot.AppendLine($"{state} [label=\"{state}\" shape=ellipse, peripheries=2, style=filled, color=yellowgreen]");
                else
                    dot.AppendLine($"{state} [label=\"{state}\"]");
            }

            dot.AppendLine("");

            foreach (string state in automata.startStates)
                dot.AppendLine($"NOTHING -> {state}");

            Dictionary<Transition, SortedSet<char>> transitions = new Dictionary<Transition, SortedSet<char>>();
            foreach (Transition transition in automata.transitions)
            {
                Dictionary<Transition, SortedSet<char>> res = transitions.Where(t =>
                        t.Key.fromState == transition.fromState &&
                        t.Key.toState == transition.toState
                    ).ToDictionary(p => p.Key, p => p.Value);

                if (res.Count() > 0){
                    KeyValuePair<Transition, SortedSet<char>> ts = res.First();
                    SortedSet<char> symbols = ts.Value;
                    symbols.Add(transition.symbol);
                    transitions[ts.Key] = symbols;
                }else {
                    SortedSet<char> sybmols = new SortedSet<char> { transition.symbol };
                    transitions.Add(transition, sybmols);
                }
            }

            foreach (KeyValuePair<Transition, SortedSet<char>> t in transitions) {
                StringBuilder sb = new StringBuilder();
                foreach(char c in t.Value)
                    if (t.Value.Last().Equals(c))
                        sb.Append(c);
                    else
                        sb.Append($"{c},");
                dot.AppendLine($"{t.Key.fromState} -> {t.Key.toState} [label=\"{sb.ToString()}\"]");
            }

            dot.AppendLine("}");

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string name = "error";
            switch (type) {
                case Type.NDFA: name = "ndfa_fms.gv"; break;
                case Type.DFA: name = "dfa_fms.gv";break;
                case Type.ODFA: name = "odfa_fms.gv"; break;
            }
            System.IO.File.WriteAllText(Path.Combine(path, $@"..\..\graphviz\{name}"), dot.ToString());

            var process = new System.Diagnostics.Process
            {
                StartInfo = { Arguments = string.Format("{0}",name) }
            };
            process.StartInfo.FileName = Path.Combine(path, @"..\..\graphviz\run.bat");
            process.Start();
            process.WaitForExit();

            return Path.Combine(path, $@"..\..\graphviz\{name}.png");
        }
    }
}

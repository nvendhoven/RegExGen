using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    class Transition<T> : IComparable<Transition<T>> where T :IComparable
    {
        public static readonly char EPSILON = '$';

        public T fromState { get; }
        public char symbol{ get; }// edge
        public T toState { get; }

        public int CompareTo(Transition<T> other)
        {
            int fromCmp = fromState.CompareTo(other.fromState);//Vergelijk de 2 fromstates
            int symbolCmp = symbol.CompareTo(other.symbol); //Vergelijk de 2 symbolen van de overgang
            int toCmp = toState.CompareTo(other.toState);//Vergelijk de 2 to States

            return (fromCmp != 0 ? fromCmp : (symbolCmp != 0 ? symbolCmp : toCmp));
        }

        // this constructor can be used to define loops:
        public Transition(T fromOrTo, char s)
        {
            this.fromState = fromOrTo;
            this.symbol = s;
            this.toState = fromOrTo;
        }

        public Transition(T from, T to)
        {
            this.fromState = from;
            this.symbol = EPSILON;
            this.toState = to;
        }


        public Transition(T from, char s, T to)
        {
            this.fromState = from;
            this.symbol = s;
            this.toState = to;
        }


        // overriding equals
        public bool equals(Object other)
        {
            if (other == null)
            {
                return false;
            }
            else if(other is Transition<T>)
            {
                return this.fromState.Equals(((Transition<T>)other).fromState) && this.toState.Equals(((Transition<T>)other).toState) && this.symbol == (((Transition<T>)other).symbol);
            }
            else
            {
                return false;
            }
        }

        public string toString()
        {
            return "(" + fromState + ", " + symbol + ")" + "-->" + toState;
        }
    }
}

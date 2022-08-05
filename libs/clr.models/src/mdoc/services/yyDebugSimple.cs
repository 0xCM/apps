//-----------------------------------------------------------------------------
// Origin: (c) 1998 Axel.Schreiner@informatik.uni-osnabrueck.de
//-----------------------------------------------------------------------------
namespace Monodoc.Ecma.yydebug
{
    using System;

    class yyDebugSimple : yyDebug
    {
        void println(string s)
        {
            Console.Error.WriteLine(s);
        }

        public void push(int state, Object value)
        {
            println("push\tstate " + state + "\tvalue " + value);
        }

        public void lex(int state, int token, string name, Object value)
        {
            println("lex\tstate " + state + "\treading " + name + "\tvalue " + value);
        }

        public void shift(int from, int to, int errorFlag)
        {
            switch (errorFlag)
            {
                default:                // normally
                    println("shift\tfrom state " + from + " to " + to);
                    break;
                case 0:
                case 1:
                case 2:     // in error recovery
                    println("shift\tfrom state " + from + " to " + to
                            + "\t" + errorFlag + " left to recover");
                    break;
                case 3:             // normally
                    println("shift\tfrom state " + from + " to " + to + "\ton error");
                    break;
            }
        }

        public void pop(int state)
        {
            println("pop\tstate " + state + "\ton error");
        }

        public void discard(int state, int token, string name, Object value)
        {
            println("discard\tstate " + state + "\ttoken " + name + "\tvalue " + value);
        }

        public void reduce(int from, int to, int rule, string text, int len)
        {
            println("reduce\tstate " + from + "\tuncover " + to
                    + "\trule (" + rule + ") " + text);
        }

        public void shift(int from, int to)
        {
            println("goto\tfrom state " + from + " to " + to);
        }

        public void accept(Object value)
        {
            println("accept\tvalue " + value);
        }

        public void error(string message)
        {
            println("error\t" + message);
        }

        public void reject()
        {
            println("reject");
        }

    }
}
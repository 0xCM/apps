//-----------------------------------------------------------------------------
// Origin: (c) 1998 Axel.Schreiner@informatik.uni-osnabrueck.de
//-----------------------------------------------------------------------------
namespace Monodoc.Ecma.yydebug
{
    using System;
    
    interface yyDebug
    {
        void push(int state, Object value);
    
        void lex(int state, int token, string name, Object value);
    
        void shift(int from, int to, int errorFlag);
    
        void pop(int state);
    
        void discard(int state, int token, string name, Object value);
    
        void reduce(int from, int to, int rule, string text, int len);
    
        void shift(int from, int to);
    
        void accept(Object value);
    
        void error(string message);
    
        void reject();
    }   
}
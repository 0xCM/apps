//-----------------------------------------------------------------------------
// Origin: (c) 1998 Axel.Schreiner@informatik.uni-osnabrueck.de
//-----------------------------------------------------------------------------
namespace Monodoc.Ecma.yyParser
{
    /** thrown for irrecoverable syntax errors and stack overflow.
        */
    class yyException : System.Exception
    {
        public yyException(string message) : base(message)
        {
        }
    }   
}
//-----------------------------------------------------------------------------
// Origin: (c) 1998 Axel.Schreiner@informatik.uni-osnabrueck.de
//-----------------------------------------------------------------------------
namespace Monodoc.Ecma.yyParser
{
    class yyUnexpectedEof : yyException
    {
        public yyUnexpectedEof(string message) : base(message)
        {
        }
        public yyUnexpectedEof() : base("")
        {
        }
    }   
}
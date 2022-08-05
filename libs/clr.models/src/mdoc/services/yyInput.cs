//-----------------------------------------------------------------------------
// Origin: (c) 1998 Axel.Schreiner@informatik.uni-osnabrueck.de
//-----------------------------------------------------------------------------
namespace Monodoc.Ecma.yyParser
{
      /** must be implemented by a scanner object to supply input to the parser.
        */
      interface yyInput
      {
          /** move on to next token.
              @return false if positioned beyond tokens.
              @throws IOException on input error.
            */
          bool advance(); // throws java.io.IOException;
          /** classifies current token.
              Should not be called if advance() returned false.
              @return current %token or single character.
            */
          int token();
          /** associated with current token.
              Should not be called if advance() returned false.
              @return value for token().
            */
          Object value();
      }   
}
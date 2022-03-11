//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [LiteralProvider]
        internal readonly struct SyntaxLiterals
        {
            public const string SeqDeclSyntax = "SEQUENCE ";

            public const string TableDeclSyntax = "()::";

            public const string EncodeTableName = "_ENCODE";

            public const string EncodeTableDecl = EncodeTableName + TableDeclSyntax;

            public const string CallSyntax = "()";

            public const string EncStep = " -> ";

            public const string DecStep = " |";

            public const string Neq = "!=";

            public const string REXW = "REXW[w]";

            public const string REXB = "REXB[b]";

            public const string REXR = "REXR[r]";

            public const string REXX = "REXX[x]";

            public const char Assign = '=';

            public const char Eq = '=';
        }
    }
}
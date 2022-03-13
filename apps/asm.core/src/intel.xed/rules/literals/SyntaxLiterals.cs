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

            public const string EncodeTableDecl = "_ENCODE" + "()::";

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

            public static bool IsCall(string src)
                => src.EndsWith(CallSyntax);

            public static bool IsSeqDecl(string src)
                => src.StartsWith(SeqDeclSyntax);

            public static bool IsEncTableDecl(string src)
                => src.EndsWith(EncodeTableDecl);

            public static bool IsTableDecl(string src)
                => src.EndsWith(TableDeclSyntax);

            public static bool IsEncStep(string src)
                => src.Contains(EncStep);

            public static bool IsDecStep(string src)
                => src.Contains(DecStep);

            public static bool IsNeq(string src)
                => src.Contains(Neq);

            public static bool IsAssign(string src)
                => src.Contains(Assign);

            public static bool IsBitfieldSeg(string src)
            {
                var i = text.index(src,Chars.LBracket);
                var j = text.index(src,Chars.RBracket);
                return i > 0 && j>1;
            }
        }
    }
}
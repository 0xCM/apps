//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleTableSpec : IComparable<RuleTableSpec>
        {
            public readonly RuleTableName Sig;

            public readonly Index<StatementSpec> Statements;

            public RuleTableSpec(RuleTableName sig, StatementSpec[] statements)
            {
                Require.invariant(sig.IsNonEmpty);
                Sig = sig;
                Statements = statements;
            }

            public string Format()
            {
                var dst = text.buffer();
                dst.AppendLine(string.Format("{0}()", Sig.ShortName));
                dst.AppendLine(Chars.LBrace);
                for(var i=0; i<Statements.Count; i++)
                    dst.IndentLine(4, Statements[i]);
                dst.AppendLine(Chars.RBrace);
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public int CompareTo(RuleTableSpec src)
                => Sig.CompareTo(src.Sig);
        }
    }
}
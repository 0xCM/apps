//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct StatementSpec
        {
            public readonly Index<RuleCell> Premise;

            public readonly Index<RuleCell> Consequent;

            [MethodImpl(Inline)]
            public StatementSpec(RuleCell[] p, RuleCell[] c)
            {
                Premise = p;
                Consequent = c;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Premise.Count == 0 && Consequent.Count == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public string Format()
            {
                var dst = text.buffer();
                for(var i=0; i<Premise.Count;  i++)
                {
                    if(i!=0)
                        dst.Append(Chars.Space);

                    dst.Append(Premise[i].Format());
                }

                dst.Append(" => ");

                for(var i=0; i<Consequent.Count;  i++)
                {
                    if(i!=0)
                        dst.Append(Chars.Space);

                    dst.Append(Consequent[i].Format());
                }
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public static StatementSpec Empty => new StatementSpec(sys.empty<RuleCell>(), sys.empty<RuleCell>());
        }
        public readonly struct RuleTableSpec : IComparable<RuleTableSpec>
        {
            public readonly RuleSig Sig;

            public readonly Index<StatementSpec> Statements;

            public RuleTableSpec(RuleSig sig, StatementSpec[] statements)
            {
                Sig = sig;
                Statements = statements;
            }

            public string Format()
            {
                var dst = text.buffer();
                dst.AppendLine(string.Format("{0}()",Sig.Name));
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
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
        public readonly record struct RuleExpr : IComparable<RuleExpr>
        {
            public const string TableId = "xed.rules.expr";

            [Render(6)]
            public readonly num12 Seq;

            [Render(6)]
            public readonly RuleTableKind Kind;

            [Render(6)]
            public readonly byte Row;

            [Render(28)]
            public readonly RuleName Name;

            [Render(1)]
            public readonly StringRef Body;

            [MethodImpl(Inline)]
            public RuleExpr(ushort seq, RuleSig sig, byte row, StringRef body)
            {
                Seq = seq;
                Name = sig.TableName;
                Kind = sig.TableKind;
                Row = row;
                Body = body;
            }

            public RuleSig Sig
            {
                [MethodImpl(Inline)]
                get => (Kind,Name);
            }

            public int CompareTo(RuleExpr src)
                => Sig.CompareTo(src.Sig);
        }
    }
}
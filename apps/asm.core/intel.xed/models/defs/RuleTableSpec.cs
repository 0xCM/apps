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
            public readonly uint TableId;

            public readonly RuleSig Sig;

            public readonly Index<StatementSpec> Statements;

            [MethodImpl(Inline)]
            public RuleTableSpec(in RuleSig sig, StatementSpec[] statements)
            {
                TableId = 0u;
                Require.invariant(sig.IsNonEmpty);
                Sig = sig;
                Statements = statements;
            }

            [MethodImpl(Inline)]
            public RuleTableSpec(uint id, in RuleSig sig, StatementSpec[] statements)
            {
                TableId = id;
                Require.invariant(sig.IsNonEmpty);
                Sig = sig;
                Statements = statements;
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => Sig.TableKind;
            }

            public string ShortName
            {
                [MethodImpl(Inline)]
                get => Sig.ShortName;
            }

            public bool IsEncTable
            {
                [MethodImpl(Inline)]
                get => Sig.IsEncTable;
            }

            public bool IsDecTable
            {
                [MethodImpl(Inline)]
                get => Sig.IsDecTable;
            }

            public uint StatementCount
            {
                [MethodImpl(Inline)]
                get => Statements.Count;
            }

            public ref StatementSpec this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Statements[i];
            }

            public ref StatementSpec this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Statements[i];
            }

            public RuleTableSpec Merge(in RuleTableSpec src)
                => new RuleTableSpec(Require.equal(Sig,src.Sig), Statements.Append(src.Statements));

            [MethodImpl(Inline)]
            public RuleTableSpec WithId(uint id)
                => new RuleTableSpec(id, Sig, Statements);

            public ReadOnlySpan<TextLine> Lines()
                => Format().Lines(trim:false);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(RuleTableSpec src)
                => Sig.CompareTo(src.Sig);
        }
    }
}
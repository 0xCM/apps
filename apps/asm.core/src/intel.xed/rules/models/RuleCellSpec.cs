//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleCellSpec : IComparable<RuleCellSpec>, IEquatable<RuleCellSpec>
        {
            public readonly bool Premise;

            public readonly CellDataKind DataKind;

            public readonly bool Nonterm;

            public readonly FieldKind Field;

            [MethodImpl(Inline)]
            public RuleCellSpec(bool premise, CellDataKind dk, bool nonterm, FieldKind field)
            {
                Premise = premise;
                Nonterm = nonterm;
                DataKind = dk;
                Field = field;
            }

            public override int GetHashCode()
                => (int)(((uint)core.u8(Premise)) << 8 | (uint)Field | (uint)DataKind << 16);

            [MethodImpl(Inline)]
            public bool Equals(RuleCellSpec src)
                => Premise == src.Premise && Field == src.Field && Nonterm == src.Nonterm;

            public override bool Equals(object src)
                => src is RuleCellSpec x && Equals(x);

            [MethodImpl(Inline)]
            public int CompareTo(RuleCellSpec src)
            {
                var result = src.Premise.CompareTo(Premise);
                if(result == 0)
                    result = ((byte)Field).CompareTo((byte)src.Field);
                return result;
            }

            public string Format()
                => string.Format("{0}:{1}:{2}", Premise ? 'P' : 'C', XedRender.format(Field), XedRender.format(DataKind));

            public override string ToString()
                => Format();
        }
    }
}